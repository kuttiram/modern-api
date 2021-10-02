using Modern.Utility.ISecurity;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Modern.Utility.Security
{
    public class AesOperation : IAesOperation
    {
        public string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string key, byte[] cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = cipherText;// Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string DecryptCombined(string FromSql, string Password)
        {
            // Encode password as UTF16-LE
            byte[] passwordBytes = Encoding.Unicode.GetBytes(Password);

            // Remove leading "0x"
            // FromSql = FromSql.Substring(2);

            int version = BitConverter.ToInt32(StringToByteArray(FromSql.Substring(0, 8)), 0);
            byte[] encrypted = null;

            HashAlgorithm hashAlgo = null;
            SymmetricAlgorithm cryptoAlgo = null;
            int keySize = (version == 1 ? 16 : 32);

            if (version == 1)
            {
                hashAlgo = SHA1.Create();
                cryptoAlgo = TripleDES.Create();
                cryptoAlgo.IV = StringToByteArray(FromSql.Substring(8, 16));
                encrypted = StringToByteArray(FromSql.Substring(24));
            }
            else if (version == 2)
            {
                hashAlgo = SHA256.Create();
                cryptoAlgo = Aes.Create();
                cryptoAlgo.IV = StringToByteArray(FromSql.Substring(8, 32));
                encrypted = StringToByteArray(FromSql.Substring(40));
            }
            else
            {
                throw new Exception("Unsupported encryption");
            }

            cryptoAlgo.Padding = PaddingMode.PKCS7;
            cryptoAlgo.Mode = CipherMode.CBC;

            hashAlgo.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);
            cryptoAlgo.Key = hashAlgo.Hash.Take(keySize).ToArray();

            byte[] decrypted = cryptoAlgo.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
            int decryptLength = BitConverter.ToInt16(decrypted, 6);
            UInt32 magic = BitConverter.ToUInt32(decrypted, 0);
            if (magic != 0xbaadf00d)
            {
                throw new Exception("Decrypt failed");
            }

            byte[] decryptedData = decrypted.Skip(8).ToArray();
            bool isUtf16 = (Array.IndexOf(decryptedData, (byte)0) != -1);
            string decryptText = (isUtf16 ? Encoding.Unicode.GetString(decryptedData) : Encoding.UTF8.GetString(decryptedData));

            return decryptText;
        }

        public string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder(Bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }

            return Result.ToString();
        }

        public byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
                                           0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                           0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }

            return Bytes;
        }

        // Method taken from https://stackoverflow.com/questions/321370/how-can-i-convert-a-hex-string-to-a-byte-array?answertab=votes#tab-top
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }        

        //public static byte[] StringToByteArray(string str)
        //{
        //    Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
        //    for (int i = 0; i <= 255; i++)
        //        hexindex.Add(i.ToString("X2"), (byte)i);

        //    List<byte> hexres = new List<byte>();
        //    for (int i = 0; i < str.Length; i += 2)
        //        hexres.Add(hexindex[str.Substring(i, 2)]);

        //    return hexres.ToArray();
        //}

        //public static byte[] StringToByteArray(string hexString)
        //{
        //    if (hexString.Length % 2 != 0)
        //    {
        //        throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
        //    }

        //    byte[] data = new byte[hexString.Length / 2];
        //    for (int index = 0; index < data.Length; index++)
        //    {
        //        string byteValue = hexString.Substring(index * 2, 2);
        //        data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        //    }

        //    return data;
        //}
    }
}

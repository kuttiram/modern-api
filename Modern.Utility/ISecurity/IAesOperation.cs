using System;
using System.Collections.Generic;
using System.Text;

namespace Modern.Utility.ISecurity
{
    public interface IAesOperation
    {
        string EncryptString(string key, string plainText);
        string DecryptString(string key, byte[] cipherText);
        string DecryptCombined(string FromSql, string Password);
        string ByteArrayToHexString(byte[] Bytes);
        byte[] HexStringToByteArray(string Hex);
    }
}

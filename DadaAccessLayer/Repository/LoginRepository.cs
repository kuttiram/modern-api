using AutoMapper;
using DadaAccessLayer.Models;
using Modern.DadaAccessLayer.IRepository;
using Modern.Object.Models;
using Modern.Utility.ISecurity;
using System;
using System.Linq;
using System.Text;

namespace Modern.DadaAccessLayer.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IMapper _mapper;
        private readonly ModernDataContext _dbContext;
        private readonly IAesOperation _aesOperation;

        public LoginRepository(IMapper mapper, ModernDataContext dbContext, IAesOperation aesOperation)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _aesOperation = aesOperation;
        }

        public LoginInfo LoginDetails(string userName, string password, out bool isFound)
        {
            string keyDetails = this._dbContext.KeyHasKey.Where(data => data.IsActive == 1).Select(val => val.KeyText).FirstOrDefault();
            if (!string.IsNullOrEmpty(keyDetails))
            {
                UserUserInfo userDetails = this._dbContext.UserUserInfo.Where(data => data.Email == userName).FirstOrDefault();
                if (userDetails != null)
                {
                    var pwdDecription = this._aesOperation.DecryptCombined(this._aesOperation.ByteArrayToHexString(userDetails.Password), keyDetails);//Encoding.Unicode.GetString(userDetails.Password));
                    if (pwdDecription == password)
                    {
                        isFound = true;
                        return this._mapper.Map<LoginInfo>(userDetails);
                    }
                    else
                    {
                        isFound = false;
                    }
                }
                else
                {
                    isFound = false;
                }
            }
            else
            {
                isFound = false;
            }
            return new LoginInfo();
        }
    }
}

using AutoMapper;
using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;
using Modern.DataAccessLayer.UOW;
using Modern.Object.Models;
using Modern.Utility.ISecurity;
using System.Linq;

namespace Modern.DataAccessLayer.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IMapper _mapper;
        //private readonly ModernDataContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAesOperation _aesOperation;

        public LoginRepository(IMapper mapper, IUnitOfWork unitOfWork, IAesOperation aesOperation)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _aesOperation = aesOperation;
        }

        public LoginInfo LoginDetails(string userName, string password, out bool isFound)
        {
            string keyDetails = this._unitOfWork.keyInfo.GetAll().Result.Where(data => data.IsActive == true).Select(val => val.KeyText).FirstOrDefault();
            if (!string.IsNullOrEmpty(keyDetails))
            {
                UserUserInfo userDetails = this._unitOfWork.user.GetAll().Result.Where(data => data.Email == userName).FirstOrDefault();
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

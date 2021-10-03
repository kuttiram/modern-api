
using Modern.BisnessAccessLayer.IRepository;
using Modern.DadaAccessLayer.IRepository;
using Modern.Object.Models;
using Modern.Utility.ISecurity;

namespace Modern.BisnessAccessLayer.Repository
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        private readonly ILoginRepository _Login;
        private readonly ITokenService _tokenService;

        public LoginBusinessLogic(ILoginRepository Login, ITokenService tokenService)
        {
            _Login = Login;
            _tokenService = tokenService;
        }

        public AuthenticateResponse LoginDetailsFromBusiness(string userName, string password)
        {
            var loginResponse = this._Login.LoginDetails(userName, password, out bool isFound);
            if (isFound)
            {
                var tokenResult = this._tokenService.Authenticate(loginResponse); ;
                tokenResult.isSucess = isFound;
                return tokenResult;
            }
            else
            {
                return new AuthenticateResponse(isFound);
            }
        }

        public bool ValidateJwtToken(string token)
        {
            if (this._tokenService.ValidateJwtToken(token))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

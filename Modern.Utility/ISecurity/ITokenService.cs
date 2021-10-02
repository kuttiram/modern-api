using Modern.Object.Models;
using System.Collections.Generic;

namespace Modern.Utility.ISecurity
{
    public interface ITokenService
    {
        AuthenticateResponse Authenticate(LoginInfo user);
        //IEnumerable<LoginInfo> GetAll();
        //LoginInfo GetById(int id);
        bool ValidateJwtToken(string token);
    }
}

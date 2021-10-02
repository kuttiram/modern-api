using Modern.Object.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modern.BisnessAccessLayer.IRepository
{
    public interface ILoginBusinessLogic
    {
        AuthenticateResponse LoginDetailsFromBusiness(string userName, string password);
        bool ValidateJwtToken(string token);
    }
}

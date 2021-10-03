using Modern.Object.Models;

namespace Modern.Object.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool isSucess { get; set; }

        public AuthenticateResponse(bool isSuccess)
        {
            isSucess = isSuccess;
        }

        public AuthenticateResponse(LoginInfo user, string token, bool isSuccess)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.UserName;
            Token = token;
            isSucess = isSuccess;
        }
    }
}

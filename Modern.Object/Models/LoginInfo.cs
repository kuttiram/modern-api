using System.Text.Json.Serialization;

namespace Modern.Object.Models
{
    public class LoginInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public byte[] Password { get; set; }
    }
}

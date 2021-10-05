using Modern.Object.Models;

namespace Modern.DataAccessLayer.IRepository
{
    public interface ILoginRepository
    {
        LoginInfo LoginDetails(string userName, string password, out bool isFound);
    }
}

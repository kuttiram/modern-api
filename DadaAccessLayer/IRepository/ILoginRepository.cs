using Modern.Object.Models;

namespace Modern.DadaAccessLayer.IRepository
{
    public interface ILoginRepository
    {
        LoginInfo LoginDetails(string userName, string password, out bool isFound);
    }
}

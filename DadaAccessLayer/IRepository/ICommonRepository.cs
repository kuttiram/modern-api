using DataAccessLayer.Models;
using Modern.DataAccessLayer.Repository;

namespace Modern.DataAccessLayer.IRepository
{
    public interface IUserRepository: IGenericRepository<UserUserInfo>
    {
    }

    public interface IKeyRepository : IGenericRepository<KeyHasKey>
    {
    }
}

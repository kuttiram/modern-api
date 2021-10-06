using Modern.DataAccessLayer.Models;

namespace Modern.DataAccessLayer.IRepository
{
    public interface IUserRepository: IGenericRepository<UserUserInfo>
    {
    }

    public interface IKeyRepository : IGenericRepository<KeyHasKey>
    {
    }

    public interface IHomeTitleRepository : IGenericRepository<PageTitle>
    {

    }

    public interface IPageContentRepository : IGenericRepository<PageContent>
    {

    }
}

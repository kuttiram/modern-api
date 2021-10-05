using Modern.DataAccessLayer.IRepository;
using System;
using System.Threading.Tasks;

namespace Modern.DataAccessLayer.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository user { get; }
        IKeyRepository keyInfo { get; }
        IHomeTitleRepository homeTitle { get; }
        IPageContentRepository contentBanner { get; }
        Task SaveAsync();
    }
}

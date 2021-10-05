using Modern.DataAccessLayer.IRepository;
using System;
using System.Threading.Tasks;

namespace Modern.DataAccessLayer.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IKeyRepository KeyInfo { get; }
        Task SaveAsync();
    }
}

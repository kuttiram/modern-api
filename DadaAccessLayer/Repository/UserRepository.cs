using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;

namespace Modern.DataAccessLayer.Repository
{
    public class UserRepository : GenericRepository<UserUserInfo>, IUserRepository
    {
        private readonly Modern_DataContext _context;
        public UserRepository(Modern_DataContext context): base(context)
        {
            _context = context;
        }
    }
}

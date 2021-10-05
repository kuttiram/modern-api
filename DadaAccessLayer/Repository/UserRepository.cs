using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;

namespace Modern.DataAccessLayer.Repository
{
    public class UserRepository : GenericRepository<UserUserInfo>, IUserRepository
    {
        private readonly ModernDataContext _context;
        public UserRepository(ModernDataContext context): base(context)
        {
            _context = context;
        }
    }
}

using DataAccessLayer.Models;
using Modern.DataAccessLayer.IRepository;

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

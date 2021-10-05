using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;

namespace Modern.DataAccessLayer.Repository
{
    public class KeyRepository : GenericRepository<KeyHasKey>, IKeyRepository
    {
        private readonly ModernDataContext _context;
        public KeyRepository(ModernDataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
    }
}

using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;

namespace Modern.DataAccessLayer.Repository
{
    public class KeyRepository : GenericRepository<KeyHasKey>, IKeyRepository
    {
        private readonly Modern_DataContext _context;
        public KeyRepository(Modern_DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
    }
}

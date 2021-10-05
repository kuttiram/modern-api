using DataAccessLayer.Models;
using Modern.DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

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

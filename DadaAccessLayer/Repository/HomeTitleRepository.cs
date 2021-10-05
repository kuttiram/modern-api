using Microsoft.EntityFrameworkCore;
using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Modern.DataAccessLayer.Repository
{
    public class HomeTitleRepository : GenericRepository<HomeTitle>, IHomeTitleRepository
    {
        private readonly ModernDataContext _context;
        public HomeTitleRepository(ModernDataContext context) : base(context)
        {
            _context = context;
        }
    }

    public class PageContentRepository : GenericRepository<PageContent>, IPageContentRepository
    {
        private readonly ModernDataContext _context;
        public PageContentRepository(ModernDataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<PageContent>> Find(Expression<Func<PageContent, bool>> predicate)
        {
            var result = await _context.PageContent.Include(s => s.PageImages).Where(predicate).ToListAsync();
            return result;
        }
    }
}

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
    public class HomeTitleRepository : GenericRepository<PageTitle>, IHomeTitleRepository
    {
        private readonly Modern_DataContext _context;
        public HomeTitleRepository(Modern_DataContext context) : base(context)
        {
            _context = context;
        }
    }

    public class PageContentRepository : GenericRepository<PageContent>, IPageContentRepository
    {
        private readonly Modern_DataContext _context;
        public PageContentRepository(Modern_DataContext context) : base(context)
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

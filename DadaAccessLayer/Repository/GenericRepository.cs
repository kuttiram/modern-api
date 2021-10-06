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
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Modern_DataContext _context;
        public GenericRepository(Modern_DataContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return (1);
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return 1;
        }

        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return 1;
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().Where(predicate).ToListAsync();
            return result;
        }
    }
}

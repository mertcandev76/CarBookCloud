using CarBookCloud.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly AppDbContext _context;

        protected RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public virtual Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public virtual async Task<List<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();
    }

}

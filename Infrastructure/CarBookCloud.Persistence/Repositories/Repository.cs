using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task AddAsync(T entity)
            => _context.Set<T>().AddAsync(entity).AsTask();

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task<List<T>> GetAllAsync()
            => _context.Set<T>().ToListAsync();

        public Task<T?> GetByIdAsync(int id)
            => _context.Set<T>().FindAsync(id).AsTask();

        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
    }
}

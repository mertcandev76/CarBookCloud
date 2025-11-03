using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Domain.Entities;
using CarBookCloud.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context) { }

        public async Task<Brand?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Brands
                .Include(b => b.Cars)
                .FirstOrDefaultAsync(b => b.BrandID == id);
        }

        public async Task<List<Brand>> GetAllWithIncludesAsync()
        {
            return await _context.Brands
                .Include(b => b.Cars)
                .ToListAsync();
        }
    }

}

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
    public class PricingRepository : RepositoryBase<Pricing>, IPricingRepository
    {
        public PricingRepository(AppDbContext context) : base(context) { }

        // Opsiyonel: Pricing + CarPricings include’lu
        public async Task<Pricing?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Pricings
                .Include(p => p.CarPricings)
                .FirstOrDefaultAsync(p => p.PricingID == id);
        }

        public async Task<List<Pricing>> GetAllWithIncludesAsync()
        {
            return await _context.Pricings
                .Include(p => p.CarPricings)
                .ToListAsync();
        }
    }
}

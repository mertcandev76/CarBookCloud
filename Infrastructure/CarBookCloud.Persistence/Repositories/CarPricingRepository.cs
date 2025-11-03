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
    public class CarPricingRepository : RepositoryBase<CarPricing>, ICarPricingRepository
    {
        public CarPricingRepository(AppDbContext context) : base(context) { }

        // Opsiyonel: CarPricing + Car + Pricing include’lu getirme
        public async Task<CarPricing?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.CarPricings
                .Include(cp => cp.Car)
                .Include(cp => cp.Pricing)
                .FirstOrDefaultAsync(cp => cp.CarPricingID == id);
        }

        public async Task<List<CarPricing>> GetAllWithIncludesAsync()
        {
            return await _context.CarPricings
                .Include(cp => cp.Car)
                .Include(cp => cp.Pricing)
                .ToListAsync();
        }

    }
}

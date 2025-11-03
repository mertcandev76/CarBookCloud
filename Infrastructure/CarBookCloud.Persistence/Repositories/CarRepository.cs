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
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context) { }

        public async Task<Car?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.CarFeatures)
                    .ThenInclude(cf => cf.Feature)
                .Include(c => c.CarPricings)
                    .ThenInclude(cp => cp.Pricing)
                .Include(c => c.CarDescriptions)
                .FirstOrDefaultAsync(c => c.CarID == id);
        }

        public async Task<List<Car>> GetAllWithIncludesAsync()
        {
            return await _context.Cars
                .Include(c => c.Brand)
                .Include(c => c.CarFeatures)
                    .ThenInclude(cf => cf.Feature)
                .Include(c => c.CarPricings)
                    .ThenInclude(cp => cp.Pricing)
                .Include(c => c.CarDescriptions)
                .ToListAsync();
        }


    }
}

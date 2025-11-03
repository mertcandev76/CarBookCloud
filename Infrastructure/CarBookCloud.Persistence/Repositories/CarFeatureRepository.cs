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
    public class CarFeatureRepository : RepositoryBase<CarFeature>, ICarFeatureRepository
    {
        public CarFeatureRepository(AppDbContext context) : base(context) { }

        public async Task<CarFeature?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.CarFeatures
                .Include(cf => cf.Car)
                .Include(cf => cf.Feature)
                .FirstOrDefaultAsync(cf => cf.CarFeatureID == id);
        }

        public async Task<List<CarFeature>> GetAllWithIncludesAsync()
        {
            return await _context.CarFeatures
                .Include(cf => cf.Car)
                .Include(cf => cf.Feature)
                .ToListAsync();
        }


    }
}

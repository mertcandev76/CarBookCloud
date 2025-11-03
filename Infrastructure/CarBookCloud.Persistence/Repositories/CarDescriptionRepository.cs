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
    public class CarDescriptionRepository : RepositoryBase<CarDescription>, ICarDescriptionRepository
    {
        public CarDescriptionRepository(AppDbContext context) : base(context) { }

        // Opsiyonel: CarDescription + Car include'lu getirme
        public async Task<CarDescription?> GetByIdWithCarAsync(int id)
        {
            return await _context.CarDescriptions
                .Include(cd => cd.Car)
                .FirstOrDefaultAsync(cd => cd.CarDescriptionID == id);
        }

        public async Task<List<CarDescription>> GetAllWithCarsAsync()
        {
            return await _context.CarDescriptions
                .Include(cd => cd.Car)
                .ToListAsync();
        }


    }
}

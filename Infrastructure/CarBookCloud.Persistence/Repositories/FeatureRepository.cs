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
    public class FeatureRepository : RepositoryBase<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext context) : base(context) { }

        public async Task<Feature?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Features
                .Include(f => f.CarFeatures)
                .FirstOrDefaultAsync(f => f.FeatureID == id);
        }

        public async Task<List<Feature>> GetAllWithIncludesAsync()
        {
            return await _context.Features
                .Include(f => f.CarFeatures)
                .ToListAsync();
        }
    }
}

using CarBookCloud.Contracts.DTOs;
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
    public class FeatureRepository(AppDbContext context) : BaseRepository(context), IFeatureRepository
    {
        public async Task<FeatureWithCarsResultDto?> GetFeatureWithCarsAsync(int featureId)
        {
            return await _context.Features
                .AsNoTracking()
                .Where(f => f.FeatureID == featureId)
                .Select(f => new FeatureWithCarsResultDto
                {
                    FeatureID = f.FeatureID,
                    Name = f.Name,
                    Cars = f.CarFeatures
                        .Where(cf => cf.Car != null) 
                        .Select(cf => cf.Car!)
                        .Select(c => new CarResultDto
                        {
                            CarID = c.CarID,
                            BrandID = c.BrandID,
                            Model = c.Model,
                            CoverImageUrl = c.CoverImageUrl,
                            Km = c.Km,
                            Transmission = c.Transmission,
                            Seat = c.Seat,
                            Lugage = c.Lugage,
                            Fuel = c.Fuel,
                            BigImageUrl = c.BigImageUrl,
                            CarFeatures = new List<CarFeatureResultDto>(),
                            CarDescriptions = new List<CarDescriptionResultDto>(),
                            CarPricings = new List<CarPricingResultDto>()
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

    }
}

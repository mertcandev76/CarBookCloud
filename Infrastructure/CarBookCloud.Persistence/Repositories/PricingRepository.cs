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
    public class PricingRepository(AppDbContext context) : BaseRepository(context), IPricingRepository
    {
        public async Task<PricingWithCarsResultDto?> GetPricingWithCarsAsync(int pricingId)
        {
            return await _context.Pricings
                .AsNoTracking()
                .Where(p => p.PricingID == pricingId)
                .Select(p => new PricingWithCarsResultDto
                {
                    PricingID = p.PricingID,
                    Name = p.Name,
                    Cars = p.CarPricings
                        .Where(cp => cp.Car != null)
                        .Select(cp => cp.Car!)
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

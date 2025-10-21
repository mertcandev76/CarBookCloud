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
    public class BrandRepository(AppDbContext context) : BaseRepository(context), IBrandRepository
    {
        public async Task<BrandResultDto?> GetBrandWithCarsAsync(int brandId)
        {
            return await _context.Brands
                .AsNoTracking()
                .Where(b => b.BrandID == brandId)
                .Select(b => new BrandResultDto
                {
                    BrandID = b.BrandID,
                    Name = b.Name,
                    Cars = b.Cars.Select(c => new CarResultDto
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

                        // alt aggregate bilgileri burada minimal tutuluyor
                        CarFeatures = new List<CarFeatureResultDto>(),
                        CarDescriptions = new List<CarDescriptionResultDto>(),
                        CarPricings = new List<CarPricingResultDto>()
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}

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
    public class CarRepository(AppDbContext context) : BaseRepository(context), ICarRepository
    {
        public async Task<IReadOnlyList<CarResultDto>> GetCarsByBrandAsync(int brandId)
        {
            return await _context.Cars
                .AsNoTracking()
                .Where(c => c.BrandID == brandId)
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

                    // Eğer detaylar gerekirse listeye dahil edilebilir, ancak liste sayısı büyüdükçe performansı kötü etkiler.
                    // Şimdilik gerektiğinde yüklensin diye boş bırakıyoruz.
                    CarFeatures = new List<CarFeatureResultDto>(),
                    CarDescriptions = new List<CarDescriptionResultDto>(),
                    CarPricings = new List<CarPricingResultDto>()

                })
                .ToListAsync();
        }

        public async Task<CarResultDto?> GetCarWithDetailsAsync(int carId)
        {
            return await _context.Cars
                .AsNoTracking()
                .Where(c => c.CarID == carId)
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

                    CarFeatures = c.CarFeatures
                        .Select(f => new CarFeatureResultDto
                        {
                            CarFeatureID = f.CarFeatureID,
                            Available = f.Available
                        }).ToList(),

                    CarDescriptions = c.CarDescriptions
                        .Select(d => new CarDescriptionResultDto
                        {
                            CarDescriptionID = d.CarDescriptionID,
                            Details = d.Details
                        }).ToList(),

                    CarPricings = c.CarPricings
                        .Select(p => new CarPricingResultDto
                        {
                            CarPricingID = p.CarPricingID,
                            Amount = p.Amount.Amount
                        }).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}

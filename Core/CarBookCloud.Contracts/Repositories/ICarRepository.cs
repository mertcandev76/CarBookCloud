using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarBookCloud.Contracts.DTOs;

namespace CarBookCloud.Contracts.Repositories
{
    // ------------------------------
    // Aggregate Root Repositories
    // ------------------------------
    public interface ICarRepository
    {
        Task<CarResultDto?> GetCarWithDetailsAsync(int carId);
        Task<IReadOnlyList<CarResultDto>> GetCarsByBrandAsync(int brandId);
    }
}

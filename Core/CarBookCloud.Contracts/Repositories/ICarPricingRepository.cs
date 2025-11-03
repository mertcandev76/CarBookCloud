using CarBookCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Repositories
{
    public interface ICarPricingRepository : IRepository<CarPricing>
    {
        Task<CarPricing?> GetByIdWithIncludesAsync(int id);
        Task<List<CarPricing>> GetAllWithIncludesAsync();
    }
}

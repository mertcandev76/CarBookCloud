using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookCloud.Contracts.DTOs;


namespace CarBookCloud.Contracts.Repositories
{
    public interface IPricingRepository 
    {
        Task<PricingWithCarsResultDto?> GetPricingWithCarsAsync(int pricingId);
    }
}

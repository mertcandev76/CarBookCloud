using CarBookCloud.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Repositories
{
    public interface IBrandRepository 
    {
        Task<BrandResultDto?> GetBrandWithCarsAsync(int brandId);
    }
}

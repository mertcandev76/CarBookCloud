using CarBookCloud.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Repositories
{
    public interface IFeatureRepository 
    {
        Task<FeatureWithCarsResultDto?> GetFeatureWithCarsAsync(int featureId);
    }
}

using CarBookCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Repositories
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task<Feature?> GetByIdWithIncludesAsync(int id);
        Task<List<Feature>> GetAllWithIncludesAsync();
    }
}

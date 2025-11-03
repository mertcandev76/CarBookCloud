using CarBookCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Repositories
{
    public interface ICarDescriptionRepository : IRepository<CarDescription>
    {
        Task<CarDescription?> GetByIdWithCarAsync(int id);
        Task<List<CarDescription>> GetAllWithCarsAsync();
    }
}

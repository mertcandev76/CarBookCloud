using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Domain.Entities;
using CarBookCloud.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Repositories
{
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext context) : base(context) { }

       
    }
}

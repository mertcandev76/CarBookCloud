using CarBookCloud.Contracts.Repositories;
using CarBookCloud.Domain.Entities;
using CarBookCloud.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Repositories
{
    public class FooterAddressRepository : RepositoryBase<FooterAddress>, IFooterAddressRepository
    {
        public FooterAddressRepository(AppDbContext context) : base(context) { }
    }
}

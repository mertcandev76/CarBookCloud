using CarBookCloud.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Persistence.Repositories
{
    public abstract class BaseRepository(AppDbContext context)
    {
        protected readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class BrandCreatedEvent(int brandID, string? name)
    {
        public int BrandID { get; } = brandID; public string? Name { get; } = name;
    }
}

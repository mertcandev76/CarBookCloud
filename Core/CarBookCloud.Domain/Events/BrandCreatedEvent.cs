using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Events
{
    public class BrandCreatedEvent
    {
        public int BrandID { get; }
        public string? Name { get; }
        public BrandCreatedEvent(int brandID, string? name) { BrandID = brandID; Name = name; }
    }
}

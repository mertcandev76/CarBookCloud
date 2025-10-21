using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class LocationCreateDto
    {
        public string? Name { get; set; }
    }

    public class LocationUpdateDto: LocationCreateDto
    {
        public int LocationID { get; set; }
    }

    public class LocationResultDto: LocationCreateDto
    {
        public int LocationID { get; set; }
    }

}

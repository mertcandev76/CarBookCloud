using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class ServiceCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
    }

    public class ServiceUpdateDto: ServiceCreateDto
    {
        public int ServiceID { get; set; }
    }

    public class ServiceResultDto: ServiceCreateDto
    {
        public int ServiceID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class PricingCreateDto
    {
        public string? Name { get; set; }
    }

    public class PricingUpdateDto: PricingCreateDto
    {
        public int PricingID { get; set; }
    }

    public class PricingResultDto: PricingCreateDto
    {
        public int PricingID { get; set; }
    }
}

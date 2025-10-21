using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class CarPricingCreateDto
    {
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }

    public class CarPricingUpdateDto: CarPricingCreateDto
    {
        public int CarPricingID { get; set; }
    }

    public class CarPricingResultDto: CarPricingCreateDto
    {
        public int CarPricingID { get; set; }
    }   
}

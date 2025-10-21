using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{

    public class CarDescriptionCreateDto
    {
        public int CarID { get; set; }
        public string? Details { get; set; }
    }

    public class CarDescriptionUpdateDto: CarDescriptionCreateDto
    {
        public int CarDescriptionID { get; set; }
    }

    public class CarDescriptionResultDto: CarDescriptionCreateDto
    {
        public int CarDescriptionID { get; set; }
    }
}

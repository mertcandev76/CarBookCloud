using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class CarFeatureCreateDto
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }

    public class CarFeatureUpdateDto: CarFeatureCreateDto
    {
        public int CarFeatureID { get; set; }
    }

    public class CarFeatureResultDto: CarFeatureCreateDto
    {
        public int CarFeatureID { get; set; }

    }
}

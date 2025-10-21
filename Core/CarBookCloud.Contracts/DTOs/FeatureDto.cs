using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class FeatureCreateDto
    {
        public string Name { get; set; } = null!;
    }

    public class FeatureUpdateDto: FeatureCreateDto
    {
        public int FeatureID { get; set; }
    }

    public class FeatureResultDto: FeatureCreateDto
    {
        public int FeatureID { get; set; }
    }

}

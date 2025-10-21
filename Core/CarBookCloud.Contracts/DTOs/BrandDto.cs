using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class CreateBrandDto
    {
        public string? Name { get; set; }

    }
    public class UpdateBrandDto: CreateBrandDto
    {
        public int BrandID { get; set; }
    }
    public class BrandResultDto:CreateBrandDto
    {
        public int BrandID { get; set; }
        
        // Minimal Car bilgisi
        public List<CarResultDto> Cars { get; set; } = new();
    }
}

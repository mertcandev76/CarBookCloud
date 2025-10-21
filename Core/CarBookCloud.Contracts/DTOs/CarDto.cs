using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class CarCreateDto
    {
        public int BrandID { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Lugage { get; set; }
        public string? Fuel { get; set; }
        public string? BigImageUrl { get; set; }
    }
    public class UpdateCarDto: CarCreateDto
    {
        public int CarID { get; set; }
    }
    public class CarResultDto: CarCreateDto
    {
        public int CarID { get; set; }
        public List<CarFeatureResultDto> CarFeatures { get; set; } = [];
        public List<CarDescriptionResultDto> CarDescriptions { get; set; } = [];
        public List<CarPricingResultDto> CarPricings { get; set; } = [];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public Brand? Brand { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Lugage { get; set; }
        public string? Fuel { get; set; }
        public string? BıgImageUrl { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; } = [];
        public ICollection<CarDescription> CarDescriptions { get; set; } = [];
        public ICollection<CarPricing> CarPricings { get; set; } = [];
    }
}

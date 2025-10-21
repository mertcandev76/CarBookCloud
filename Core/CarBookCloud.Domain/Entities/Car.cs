using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    // -----------------------------
    // Aggregate Root: Car
    // Alt Entity: CarPricing, CarFeature, CarDescription
    // -----------------------------
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
        public string? BigImageUrl { get; set; }

        public ICollection<CarFeature> CarFeatures { get; set; } = [];
        public ICollection<CarDescription> CarDescriptions { get; set; } = [];
        public ICollection<CarPricing> CarPricings { get; set; } = [];

        public List<object> DomainEvents { get; } = [];

        public Car()
        {
            DomainEvents.Add(new CarCreatedEvent(CarID, Model));
        }

        // İş kuralları / Aggregate Root mantığı
        public void AddPricing(CarPricing pricing)
        {
            if (pricing.Amount.Amount <= 0)
                throw new ArgumentException("Fiyat 0'dan büyük olmalı.");

            pricing.Car = this;
            CarPricings.Add(pricing);

            DomainEvents.Add(new CarPricingAddedEvent(pricing.CarPricingID, pricing.Amount.Amount));
        }

        public void AddFeature(CarFeature feature)
        {
            feature.Car = this;
            CarFeatures.Add(feature);

            DomainEvents.Add(new CarFeatureUpdatedEvent(feature.CarFeatureID, feature.Available));
        }

        public void AddDescription(CarDescription description)
        {
            description.Car = this;
            CarDescriptions.Add(description);

            DomainEvents.Add(new CarDescriptionAddedEvent(description.CarDescriptionID, CarID));
        }
    }
}

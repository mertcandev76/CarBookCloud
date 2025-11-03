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
    public class Car : IHasDomainEvents
    {
        public int CarID { get; private set; }
        public int BrandID { get; private set; }
        public Brand? Brand { get; private set; }
        public string Model { get; private set; } = string.Empty;
        public string? CoverImageUrl { get; private set; }
        public int Km { get; private set; }
        public string? Transmission { get; private set; }
        public byte Seat { get; private set; }
        public byte Lugage { get; private set; }
        public string? Fuel { get; private set; }
        public string? BigImageUrl { get; private set; }

        public ICollection<CarFeature> CarFeatures { get; private set; } = [];
        public ICollection<CarDescription> CarDescriptions { get; private set; } = [];
        public ICollection<CarPricing> CarPricings { get; private set; } = [];

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Car() { } // EF Core için gerekli

        //Factory Method
        public static Car Create(int brandId, string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model boş olamaz.", nameof(model));

            var car = new Car
            {
                BrandID = brandId,
                Model = model
            };

            car._domainEvents.Add(new CarCreatedEvent(car.Model));
            return car;
        }

        //PRICING
        public void AddPricing(CarPricing pricing)
        {
            if (pricing.Amount.Amount <= 0)
                throw new ArgumentException("Fiyat 0'dan büyük olmalı.", nameof(pricing));

            pricing.AttachToCar(this);
            CarPricings.Add(pricing);

            _domainEvents.Add(new CarPricingAddedEvent(CarID, pricing.Amount.Amount));
        }

        //FEATURE
        public void AddFeature(CarFeature feature)
        {
            feature.AttachToCar(this);
            CarFeatures.Add(feature);

            _domainEvents.Add(new CarFeatureUpdatedEvent(CarID, feature.Available));
        }

        //DESCRIPTION
            
        public void AddDescription(CarDescription description)
        {
            description.AttachToCar(this);
            CarDescriptions.Add(description);

            _domainEvents.Add(new CarDescriptionAddedEvent(CarID, description.CarDescriptionID));
        }

        //Domain Event temizleyici
        public void ClearDomainEvents() => _domainEvents.Clear();
    }

}

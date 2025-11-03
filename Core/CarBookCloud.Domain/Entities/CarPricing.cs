using CarBookCloud.Domain.Events;
using CarBookCloud.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class CarPricing : IHasDomainEvents
    {
        public int CarPricingID { get; private set; }
        public int CarID { get; private set; }
        public Car? Car { get; private set; }

        public int PricingID { get; private set; }
        public Pricing? Pricing { get; private set; }

        public Price Amount { get; private set; } = default!;

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private CarPricing() { } // EF Core için

        private CarPricing(Price amount)
        {
            SetAmount(amount);
        }

        // -------------------------
        // Factory Method
        // -------------------------
        public static CarPricing Create(Price amount)
        {
            var pricing = new CarPricing(amount);
            pricing._domainEvents.Add(new CarPricingAddedEvent(pricing.CarID, amount.Amount));
            return pricing;
        }

        // -------------------------
        // Güncelleme metodu
        // -------------------------
        public void SetAmount(Price amount)
        {
            if (amount.Amount <= 0)
                throw new ArgumentException("Fiyat 0'dan büyük olmalı.", nameof(amount));

            bool isUpdated = CarPricingID > 0 && Amount != amount;
            Amount = amount;

            if (isUpdated)
            {
                _domainEvents.Add(new CarPricingAddedEvent(CarID, Amount.Amount));
            }
        }

        // -------------------------
        // Aggregate root ile ilişkilendirme
        // -------------------------
        internal void AttachToCar(Car car)
        {
            Car = car;
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}

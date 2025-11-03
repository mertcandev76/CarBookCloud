using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class CarDescription : IHasDomainEvents
    {
        public int CarDescriptionID { get; private set; }
        public int CarID { get; private set; }
        public Car? Car { get; private set; }
        public string Details { get; private set; } = default!;

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private CarDescription() { } // EF Core için

        private CarDescription(int carId, string details)
        {
            CarID = carId;
            SetDetails(details);
        }

        // -------------------------
        // Factory Method
        // -------------------------
        public static CarDescription Create(int carId, string details)
        {
            var description = new CarDescription(carId, details);
            description._domainEvents.Add(new CarDescriptionAddedEvent(carId, description.CarDescriptionID));
            return description;
        }

        // -------------------------
        // Güncelleme metodu
        // -------------------------
        public void SetDetails(string details)
        {
            if (string.IsNullOrWhiteSpace(details))
                throw new ArgumentException("Detaylar boş olamaz.", nameof(details));
            if (details.Length < 5)
                throw new ArgumentException("Detaylar en az 5 karakter olmalı.", nameof(details));

            bool isUpdated = CarDescriptionID > 0 && Details != details;
            Details = details;

            if (isUpdated)
            {
                _domainEvents.Add(new CarDescriptionUpdatedEvent(CarDescriptionID, CarID));
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

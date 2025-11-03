using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class CarFeature : IHasDomainEvents
    {
        public int CarFeatureID { get; private set; }
        public int CarID { get; private set; }
        public Car? Car { get; private set; }
        public int FeatureID { get; private set; }
        public Feature? Feature { get; private set; }
        public bool Available { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private CarFeature() { } // EF Core için

        private CarFeature(int carId, int featureId, bool available)
        {
            CarID = carId;
            FeatureID = featureId;
            SetAvailable(available);
        }

        // -------------------------
        // Factory Method
        // -------------------------
        public static CarFeature Create(int carId, int featureId, bool available)
        {
            var carFeature = new CarFeature(carId, featureId, available);
            carFeature._domainEvents.Add(new CarFeatureUpdatedEvent(carId, available));
            return carFeature;
        }

        // -------------------------
        // Güncelleme metodu
        // -------------------------
        public void SetAvailable(bool available)
        {
            bool isUpdated = CarFeatureID > 0 && Available != available;
            Available = available;

            if (isUpdated)
            {
                _domainEvents.Add(new CarFeatureUpdatedEvent(CarFeatureID, Available));
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

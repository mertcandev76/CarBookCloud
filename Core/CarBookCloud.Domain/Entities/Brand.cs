using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    // -----------------------------
    // Aggregate Root: Brand
    // Alt Entity: Car (Car bağımsız root)
    // -----------------------------
    public class Brand : IHasDomainEvents
    {
        public int BrandID { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<Car> Cars { get; private set; } = [];

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Brand() { } 

        private Brand(string name)
        {
            SetName(name);
        }

        public static Brand Create(string name)
        {
            var brand = new Brand(name);
            brand._domainEvents.Add(new BrandCreatedEvent(brand.BrandID, brand.Name));
            return brand;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Marka adı boş olamaz.", nameof(name));

            bool isUpdated = BrandID > 0 && Name != name;
            Name = name;

            if (isUpdated)
                _domainEvents.Add(new BrandNameChangedEvent(BrandID, Name));
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }

}

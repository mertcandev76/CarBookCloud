using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Category : IHasDomainEvents
    {
        public int CategoryID { get; private set; }
        public string Name { get; private set; } = default!;

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Category() { } 

        private Category(string name)
        {
            SetName(name);
        }

        //Factory Method
        public static Category Create(string name)
        {
            var category = new Category(name);
            category.AddDomainEvent(new CategoryCreatedEvent(category.CategoryID, category.Name));
            return category;
        }

        //Güncelleme metodu
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Kategori adı boş olamaz.", nameof(newName));

            if (newName == Name)
                return;

            var oldName = Name;
            Name = newName;

            AddDomainEvent(new CategoryNameChangedEvent(CategoryID, oldName, newName));
        }

        //Yardımcılar
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Kategori adı boş olamaz.", nameof(name));

            Name = name;
        }

        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}

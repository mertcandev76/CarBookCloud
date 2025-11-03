using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Testimonial : IHasDomainEvents
    {
        public int TestimonialID { get; private set; }
        public string Name { get; private set; } = default!;
        public string? Title { get; private set; }
        public string? Comment { get; private set; }
        public string? ImageUrl { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Testimonial() { } // EF Core için

        //Factory Method
        public static Testimonial Create(string name, string? title = null, string? comment = null, string? imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ad boş olamaz.", nameof(name));

            if (!string.IsNullOrWhiteSpace(imageUrl) && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                throw new ArgumentException("Geçersiz Resim URL formatı.", nameof(imageUrl));

            var testimonial = new Testimonial
            {
                Name = name,
                Title = title,
                Comment = comment,
                ImageUrl = imageUrl
            };

            testimonial.AddDomainEvent(new TestimonialCreatedEvent(testimonial.TestimonialID, testimonial.Name));
            return testimonial;
        }

        //Güncelleme metodu
        public void Update(string? name = null, string? title = null, string? comment = null, string? imageUrl = null)
        {
            bool isUpdated = false;
            string oldName = Name;

            if (!string.IsNullOrWhiteSpace(name) && Name != name)
            {
                Name = name;
                AddDomainEvent(new TestimonialNameChangedEvent(TestimonialID, oldName, name));
                isUpdated = true;
            }

            if (Title != title)
            {
                Title = title;
                isUpdated = true;
            }

            if (Comment != comment)
            {
                Comment = comment;
                isUpdated = true;
            }

            if (ImageUrl != imageUrl)
            {
                if (!string.IsNullOrWhiteSpace(imageUrl) && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                    throw new ArgumentException("Geçersiz Resim URL formatı.", nameof(imageUrl));

                ImageUrl = imageUrl;
                isUpdated = true;
            }

            if (isUpdated)
                AddDomainEvent(new TestimonialUpdatedEvent(TestimonialID, Name));
        }

        //Yardımcılar
        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}

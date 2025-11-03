using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class About : IHasDomainEvents
    {
        public int AboutID { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private About() { } // EF Core için

        // ✅ Factory Method (oluşturma)
        public static About Create(string title, string? description = null, string? imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Başlık boş olamaz.", nameof(title));

            if (!string.IsNullOrWhiteSpace(description) && description.Length < 10)
                throw new ArgumentException("Açıklama en az 10 karakter olmalı.", nameof(description));

            if (!string.IsNullOrWhiteSpace(imageUrl) && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                throw new ArgumentException("Geçersiz Resim URL formatı.", nameof(imageUrl));

            var about = new About
            {
                Title = title,
                Description = description,
                ImageUrl = imageUrl
            };

            about.AddDomainEvent(new AboutCreatedEvent(title));

            return about;
        }

        // ✅ Title değiştirme (event üretir)
        public void SetTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Başlık boş olamaz.", nameof(newTitle));

            if (Title != newTitle)
            {
                Title = newTitle;
                AddDomainEvent(new AboutTitleChangedEvent(AboutID, newTitle));
            }
        }

        public void SetDescription(string? description)
        {
            if (!string.IsNullOrWhiteSpace(description) && description.Length < 10)
                throw new ArgumentException("Açıklama en az 10 karakter olmalı.", nameof(description));

            Description = description;
        }

        public void SetImageUrl(string? imageUrl)
        {
            if (!string.IsNullOrWhiteSpace(imageUrl) && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                throw new ArgumentException("Geçersiz Resim URL formatı.", nameof(imageUrl));

            ImageUrl = imageUrl;
        }

        // Domain Event ekleme/temizleme yardımcıları
        private void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }

}

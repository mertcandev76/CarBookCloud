using CarBookCloud.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.Entities
{
    public class Banner : IHasDomainEvents
    {
        public int BannerID { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string? VideoDescription { get; private set; }
        public string? VideoUrl { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Banner() { } 

        private Banner(string title, string? description, string? videoDescription, string? videoUrl)
        {
            Title = title;
            Description = description;
            VideoDescription = videoDescription;
            VideoUrl = videoUrl;
        }

        public static Banner Create(string title, string? description = null, string? videoDescription = null, string? videoUrl = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Başlık boş olamaz.", nameof(title));

            var banner = new Banner(title, description, videoDescription, videoUrl);

            banner._domainEvents.Add(new BannerCreatedEvent(banner.BannerID, banner.Title));

            return banner;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Başlık boş olamaz.", nameof(title));

            bool isUpdated = BannerID > 0 && Title != title;
            Title = title;

            if (isUpdated)
                _domainEvents.Add(new BannerTitleChangedEvent(BannerID, Title));
        }

        public void SetDescription(string? description)
        {
            if (!string.IsNullOrWhiteSpace(description) && description.Length < 10)
                throw new ArgumentException("Açıklama en az 10 karakter olmalı.", nameof(description));

            Description = description;
        }

        public void SetVideoDescription(string? videoDescription)
        {
            if (!string.IsNullOrWhiteSpace(videoDescription) && videoDescription.Length < 10)
                throw new ArgumentException("Video Açıklama en az 10 karakter olmalı.", nameof(videoDescription));

            VideoDescription = videoDescription;
        }

        public void SetVideoUrl(string? videoUrl)
        {
            if (!string.IsNullOrWhiteSpace(videoUrl) && !Uri.IsWellFormedUriString(videoUrl, UriKind.Absolute))
                throw new ArgumentException("Geçersiz Video URL formatı.", nameof(videoUrl));

            VideoUrl = videoUrl;
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}

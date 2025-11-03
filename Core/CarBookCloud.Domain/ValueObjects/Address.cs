using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string? PostalCode { get; }

        public Address(string street, string city, string? postalCode = null)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Adresin sokağı girilmesi zorunludur.");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Şehir alanı zorunludur.");

            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public override bool Equals(object? obj) =>
            obj is Address other &&
            Street == other.Street &&
            City == other.City &&
            PostalCode == other.PostalCode;

        public override int GetHashCode() => HashCode.Combine(Street, City, PostalCode);
    }


}

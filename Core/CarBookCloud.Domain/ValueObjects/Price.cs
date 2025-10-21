using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Domain.ValueObjects
{
    public class Price
    {
        public decimal Amount { get; }

        public Price(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Fiyat negatif olamaz.");
            Amount = amount;
        }

        public override bool Equals(object? obj) => obj is Price other && Amount == other.Amount;
        public override int GetHashCode() => Amount.GetHashCode();
    }
}

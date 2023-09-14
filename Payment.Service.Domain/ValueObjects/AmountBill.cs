using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.ValueObjects
{
    public record AmountBill : ValueObject
    {
        public decimal Value { get; init; }

        public AmountBill(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The amount should be greater than 0");
            }
            Value = value;
        }

        public static implicit operator decimal(AmountBill amount) => amount.Value;

        public static implicit operator AmountBill(decimal amount) => new(amount);
    }
}

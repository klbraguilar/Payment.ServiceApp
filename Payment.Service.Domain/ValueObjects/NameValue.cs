using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.ValueObjects
{
    public record NameValue : ValueObject
    {
        public string Value { get; set; }

        public NameValue(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            Value = value;
        }

        public static implicit operator string(NameValue clientName) => clientName.Value;

        public static implicit operator NameValue(string value) => new(value);
    }
}

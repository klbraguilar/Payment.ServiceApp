using Payment.Service.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Model.Category
{
    public class Category : Entity
    {
        public NameValue Name { get; private set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Category()
        {

        }
    }
}

using Payment.Service.Domain.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Factories
{
    public class CategoryFactory : ICategoryFactory
    {
        public Category Create(string name)
        {
            return new Category(name);
        }
    }
}

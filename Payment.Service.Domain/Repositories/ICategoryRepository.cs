using Payment.Service.Domain.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Repositories
{
    public interface ICategoryRepository : IRepositoryEntity<Category, Guid>
    {
        Task UpdateAsync(Category category);
    }
}

using Payment.Service.Domain.Model.Category;
using Payment.Service.Domain.Repositories;
using Payment.Service.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WriteDBContext _dbContext;

        public CategoryRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Category cat)
        {
            await _dbContext.Category.AddAsync(cat);
        }

        public async Task<Category?> FindByIdAsync(Guid id)
        {
            return await _dbContext.Category.FindAsync(id);
        }

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

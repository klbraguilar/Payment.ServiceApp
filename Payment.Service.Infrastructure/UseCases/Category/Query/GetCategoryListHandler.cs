using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Service.Application.DTOs;
using Payment.Service.Application.UseCases.Category.Query.GetCategoriesList;
using Payment.Service.Infrastructure.EF.Contexts;
using Payment.Service.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.UseCases.Category.Query
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoriesListQuery, ICollection<CategoryDto>>
    {
        private readonly DbSet<CategoryReadModel> _category;

        public GetCategoryListHandler(ReadDBContext category)
        {
            _category = category.Category;
        }
        public async Task<ICollection<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _category.AsNoTracking();

            return await query.Select(client =>
                new CategoryDto
                {
                    Id = client.Id,
                    Name = client.Name
                }).ToListAsync(cancellationToken);
        }
    }
}

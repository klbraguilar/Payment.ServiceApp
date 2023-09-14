using MediatR;
using Payment.Service.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Category.Query.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<ICollection<CategoryDto>>
    {

    }
}

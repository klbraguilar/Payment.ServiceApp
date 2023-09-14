using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Service.Application.UseCases.Category.Command.CreateCategory;
using Payment.Service.Application.UseCases.Category.Query.GetCategoriesList;

namespace Payment.Service.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var clientId = await _mediator.Send(createCategoryCommand);
            return Ok(clientId);
        }

        [HttpGet]
        public async Task<IActionResult> getAllCategories()
        {
            var categories = await _mediator.Send(new GetCategoriesListQuery()
            {
            });
            return Ok(categories);
        }
    }
}

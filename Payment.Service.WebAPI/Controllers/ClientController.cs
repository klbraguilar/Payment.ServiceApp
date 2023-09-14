using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Service.Application.UseCases.Client.Command.CreateClient;

namespace Payment.Service.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand createClientCommand)
        {
            var clientId = await _mediator.Send(createClientCommand);
            return Ok(clientId);
        }
    }
}

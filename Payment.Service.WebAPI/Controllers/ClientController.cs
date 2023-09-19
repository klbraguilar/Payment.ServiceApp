using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Service.Application.DTOs;
using Payment.Service.Application.UseCases.Client.Command.CreateClient;
using Payment.Service.Application.UseCases.Client.Query.GetClientsList;

namespace Payment.Service.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand createClientCommand)
        {
            var clientId = await _mediator.Send(createClientCommand);
            return Ok(clientId);
        }

        [HttpGet]
        public async Task<IActionResult> searchClients(string searchTerm = "")
        {
            var clients = await _mediator.Send(new GetClientsListQuery()
            {
                SearchTerm = searchTerm
            });
            return Ok(clients);
        }
    }
}

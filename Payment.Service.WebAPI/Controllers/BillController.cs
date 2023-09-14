using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Service.Application.UseCases.Bill.Command.CreateBill;

namespace Payment.Service.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillCommand createBillCommand)
        {
            var billId = await _mediator.Send(createBillCommand);
            return Ok(billId);
        }
    }
}

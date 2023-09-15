using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Service.Application.UseCases.Bill.Command.CreateBill;
using Payment.Service.Application.UseCases.Bill.Command.PayBill;
using Payment.Service.Application.UseCases.Bill.Command.Quey.GetBillsListQuery;
using Payment.Service.Application.UseCases.Bill.Command.Quey.GetPendingBillsById;
using Payment.Service.Application.UseCases.Client.Query.GetClientsList;
using Payment.Service.Application.UseCases.EventHandlers;

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

        [HttpGet]
        public async Task<IActionResult> getAllCategories()
        {
            var bills = await _mediator.Send(new GetBillsListQuery()
            {
            });
            return Ok(bills);
        }

        [HttpGet("PendingBills")]
        public async Task<IActionResult> getPendingBillsById(Guid searchTerm)
        {
            var pendingBills = await _mediator.Send(new GetPendingBIllsById()
            {
                SearchTerm = searchTerm
            });
            return Ok(pendingBills);
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> PayPendingBill([FromBody] PayBillCommand payBillCommand)
        {
            var pendingBills = await _mediator.Send(payBillCommand.searchterm);
            return Ok(pendingBills);
        }
    }
}

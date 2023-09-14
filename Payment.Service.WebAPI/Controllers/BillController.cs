using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Service.Application.UseCases.Bill.Command.CreateBill;
using Payment.Service.Application.UseCases.Bill.Command.Quey.GetBillsListQuery;
using Payment.Service.Application.UseCases.Bill.Command.Quey.GetPendingBillsById;
using Payment.Service.Application.UseCases.Client.Query.GetClientsList;

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

        [HttpGet("GetPlatformById")]
        public async Task<IActionResult> getPendingBillsById(Guid searchTerm)
        {
            var pendingBills = await _mediator.Send(new GetPendingBIllsById()
            {
                SearchTerm = searchTerm
            });
            return Ok(pendingBills);
        }
    }
}

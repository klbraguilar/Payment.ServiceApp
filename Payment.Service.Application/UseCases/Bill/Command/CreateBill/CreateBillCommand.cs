using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Bill.Command.CreateBill
{
    public class CreateBillCommand : IRequest<Guid>
    {
        public Guid ClientId { get; set; }
        public Guid CategoryId { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Bill.Command.PayBill
{
    public class PayBillCommand : IRequest<Guid>
    {
        public Guid searchterm { get; set; }
    }
}

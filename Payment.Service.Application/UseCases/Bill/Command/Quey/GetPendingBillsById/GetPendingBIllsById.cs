using MediatR;
using Payment.Service.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Bill.Command.Quey.GetPendingBillsById
{
    public class GetPendingBIllsById : IRequest<ICollection<PendingBillDto>>
    {
        public Guid SearchTerm { get; set; }
    }
}

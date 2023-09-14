using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Service.Application.DTOs;
using Payment.Service.Application.UseCases.Bill.Command.Quey.GetPendingBillsById;
using Payment.Service.Infrastructure.EF.Contexts;
using Payment.Service.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.UseCases.Bill.Query
{
    public class GetPendingBillsByIdHandler : IRequestHandler<GetPendingBIllsById, ICollection<PendingBillDto>>
    {
        private readonly DbSet<BillReadModel> _bill;

        public GetPendingBillsByIdHandler(ReadDBContext bill)
        {
            _bill = bill.Bill;
        }

        public async Task<ICollection<PendingBillDto>> Handle(GetPendingBIllsById request, CancellationToken cancellationToken)
        {
            var query = _bill.AsNoTracking();
            if (!String.IsNullOrEmpty(request.SearchTerm.ToString()))
            {
                query = query.Where(x => x.ClientId == request.SearchTerm);
            }

            return await query.Select(bill =>
                new PendingBillDto
                {
                    Id = bill.Id,
                    Client = bill.ClientId,
                    Period = bill.Period,
                    State = bill.State,
                    Amount= bill.Amount
                }).ToListAsync(cancellationToken);
        }
    }
}

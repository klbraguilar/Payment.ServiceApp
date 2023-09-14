using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Service.Application.DTOs;
using Payment.Service.Application.UseCases.Bill.Command.Quey.GetBillsListQuery;
using Payment.Service.Domain.Model.Category;
using Payment.Service.Infrastructure.EF.Contexts;
using Payment.Service.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.UseCases.Bill.Query
{
    public class GetBillListHandler : IRequestHandler<GetBillsListQuery, ICollection<BillDto>>
    {
        private readonly DbSet<BillReadModel> _bill;

        public GetBillListHandler(ReadDBContext bill)
        {
            _bill = bill.Bill;
        }

        public async Task<ICollection<BillDto>> Handle(GetBillsListQuery request, CancellationToken cancellationToken)
        {
            var query = _bill.AsNoTracking();

            return await query.Select(bill =>
                new BillDto
                {
                    Id = bill.Id,
                    ClientId = bill.ClientId,
                    CategoryID = bill.CategoryId,
                    Period= bill.Period,
                    State= bill.State,
                    Amount= bill.Amount,
                }).ToListAsync(cancellationToken);
        }
    }
}

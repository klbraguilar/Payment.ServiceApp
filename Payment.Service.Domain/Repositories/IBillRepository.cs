using Payment.Service.Domain.Model.Billing;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Repositories
{
    public interface IBillRepository : IRepository<Bill, Guid>
    {
        Task UpdateAsync(Bill bill);
    }
}

using Payment.Service.Domain.Model.Billing;
using Payment.Service.Domain.Repositories;
using Payment.Service.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly WriteDBContext _dbContext;

        public BillRepository(WriteDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Bill bill)
        {
            await _dbContext.Bill.AddAsync(bill);
        }

        public Task<Bill?> FindByIdAsync(Guid id)
        {
            return _dbContext.Bill.FindAsync(id);
        }

        public async Task UpdateAsync(Bill bill)
        {
            
            throw new NotImplementedException();
        }
    }
}

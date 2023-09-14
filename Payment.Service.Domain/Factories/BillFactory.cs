using Payment.Service.Domain.Model.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Factories
{
    public class BillFactory : IBillFactory
    {
        public Bill Create(Guid clientId, Guid categoryId,string period, decimal amount)
        {
            return new Bill(clientId, categoryId, period, amount);
        }
    }
}

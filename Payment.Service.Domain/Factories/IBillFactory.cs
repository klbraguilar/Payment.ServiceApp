using Payment.Service.Domain.Model.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Factories
{
    public interface IBillFactory
    {
        Bill Create(Guid clientId, Guid categoryID,string period, decimal amount);
        Bill ConfirmPay(Bill billToConfirm);
    }
}

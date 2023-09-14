using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Exceptions
{
    public class ConfirmationBillException : Exception
    {
        public ConfirmationBillException(string reason)
            : base("La transacción no puede ser confirmada por que " + reason)
        {}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Exceptions
{
    public class ClientExceptionCreation : Exception
    {
        public ClientExceptionCreation(string reason)
            : base("The client cannot be created because: " + reason) { }
    }
}

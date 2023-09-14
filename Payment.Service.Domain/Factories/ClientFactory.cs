using Payment.Service.Domain.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Factories
{
    public class ClientFactory : IClientFactory
    {
        public Client Create(string name)
        {
            return new Client(name);
        }
    }
}

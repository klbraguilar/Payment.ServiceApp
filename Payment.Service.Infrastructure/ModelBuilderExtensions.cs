using Microsoft.EntityFrameworkCore;
using Payment.Service.Domain.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payment.Service.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed()
        {

            Client client1 = new Client("Joseph Carlton");
            Client client2 = new Client("Maria Juarez");
            Client client3 = new Client("Albert Kenny");
            Client client4 = new Client("Jessica Phillips");
            Client client5 = new Client("Charles Johnson");
                

        }
    }
}

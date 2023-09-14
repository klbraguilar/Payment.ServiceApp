using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Client.Command.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}

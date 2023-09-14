using MediatR;
using Payment.Service.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Client.Query.GetClientsList
{
    public class GetClientsListQuery : IRequest<ICollection<ClientDto>>
    {
        public string SearchTerm { get; set; }

    }
}

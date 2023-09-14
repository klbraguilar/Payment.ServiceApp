using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Service.Application.DTOs;
using Payment.Service.Application.UseCases.Client.Query.GetClientsList;
using Payment.Service.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.UseCases.Client.Query
{
    
    public class GetClientListHandler : IRequestHandler<GetClientsListQuery, ICollection<ClientDto>>
    {
        private readonly DbSet<ClientReadModel> _client;

        public GetClientListHandler(DbSet<ClientReadModel> client)
        {
            _client = client;
        }

        public async Task<ICollection<ClientDto>> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
        {
            var query = _client.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.Name.Contains(request.SearchTerm));
            }

            return await query.Select(client =>
                new ClientDto
                {
                    Id= client.Id,
                    Name = client.Name
                }).ToListAsync(cancellationToken);
        }
    }
}

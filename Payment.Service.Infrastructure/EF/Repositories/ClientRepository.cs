using Microsoft.EntityFrameworkCore;
using Payment.Service.Domain.Model.Client;
using Payment.Service.Domain.Repositories;
using Payment.Service.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly WriteDBContext _writeDbContext;

        public ClientRepository(WriteDBContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(Client obj)
        {
            await _writeDbContext.Client.AddAsync(obj);
        }

        public async Task<Client?> FindByIdAsync(Guid id)
        {
            return await _writeDbContext.Client.FindAsync(id);
        }

        public Task UpdateAsync(Client client)
        {
            _writeDbContext.Client.Update(client);
            return Task.CompletedTask;
        }
    }
}

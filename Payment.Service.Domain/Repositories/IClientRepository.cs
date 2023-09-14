using Payment.Service.Domain.Model.Client;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Repositories
{
    public interface IClientRepository : IRepositoryEntity<Client, Guid>
    {
        Task UpdateAsync(Client client);
    }
}

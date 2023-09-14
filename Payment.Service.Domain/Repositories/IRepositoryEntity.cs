using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Repositories
{
    public interface IRepositoryEntity<T, in TId> where T : Entity
    {
        Task<T?> FindByIdAsync(TId id);

        Task CreateAsync(T obj);

    }
}

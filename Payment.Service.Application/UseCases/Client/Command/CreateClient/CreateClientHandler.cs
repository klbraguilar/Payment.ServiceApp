using MediatR;
using Payment.Service.Domain.Factories;
using Payment.Service.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Client.Command.CreateClient
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientFactory _clientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientHandler(IClientRepository clientRepository, IClientFactory clientFactory, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _clientFactory = clientFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var createdClient = _clientFactory.Create(request.Name);
            await _clientRepository.CreateAsync(createdClient);
            await _unitOfWork.Commit();
            return createdClient.Id;
        }
    }
}

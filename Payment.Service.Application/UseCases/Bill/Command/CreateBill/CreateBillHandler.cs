using MediatR;
using Payment.Service.Application.UseCases.Client.Command.CreateClient;
using Payment.Service.Domain.Factories;
using Payment.Service.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Bill.Command.CreateBill
{
    public class CreateBillHandler : IRequestHandler<CreateBillCommand, Guid>
    {
        private readonly IBillRepository _billRepository;
        private readonly IBillFactory _billFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBillHandler(IBillRepository billRepository, IBillFactory billFactory, IUnitOfWork unitOfWork)
        {
            _billRepository = billRepository;
            _billFactory = billFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var createdBill = _billFactory.Create(request.ClientId, request.CategoryId, request.Period, request.Amount);
            await _billRepository.CreateAsync(createdBill);
            await _unitOfWork.Commit();
            return createdBill.Id;
        }
    }
}

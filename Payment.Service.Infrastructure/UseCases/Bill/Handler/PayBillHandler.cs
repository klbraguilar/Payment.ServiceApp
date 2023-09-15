using MediatR;
using Microsoft.Extensions.Logging;
using Payment.Service.Application.UseCases.Bill.Command.PayBill;
using Payment.Service.Domain.Exceptions;
using Payment.Service.Domain.Factories;
using Payment.Service.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.UseCases.Bill.Handler
{
    public class PayBillHandler : IRequestHandler<PayBillCommand, Guid>
    {
        private readonly IBillRepository _billRepository;
        private readonly IBillFactory _billFactory;
        private readonly IUnitOfWork _unitOfWork;

        public PayBillHandler(IBillRepository billRepository, IBillFactory billFactory, IUnitOfWork unitOfWork)
        {
            _billRepository = billRepository;
            _billFactory = billFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(PayBillCommand request, CancellationToken cancellationToken)
        {
            Guid newGuid = Guid.Parse(request.searchterm);
            var getPendingBill = _billRepository.FindByIdAsync(newGuid);
            if (getPendingBill == null)
            {
                throw new ConfirmationBillException("Pending bill: " + request.searchterm + "doesn't exist.");
            }
            _billFactory.ConfirmPay(getPendingBill.Result);
            await _unitOfWork.Commit();
            return getPendingBill.Result.Id;
        }
    }
}

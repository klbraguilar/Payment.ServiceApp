using MediatR;
using Payment.Service.Domain.DomainEvents;
using Payment.Service.Domain.Exceptions;
using Payment.Service.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.EventHandlers
{
    public class PayBill : INotificationHandler<ConfirmPayment>
    {
        private readonly IBillRepository _billRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PayBill(IBillRepository billRepository, IUnitOfWork unitOfWork)
        {
            _billRepository = billRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ConfirmPayment evento, CancellationToken cancellationToken)
        {
            var pendingBill = await _billRepository.FindByIdAsync(evento.Id);
            if (pendingBill == null)
            {
                throw new ConfirmationBillException("Pending bill: " + evento.Id + "doesn't exist.");
            }
            pendingBill.Confirmar();

            await _unitOfWork.Commit();
        }
    }
}

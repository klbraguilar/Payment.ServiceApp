using MediatR;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.DomainEvents
{
    public record ConfirmPayment : DomainEvent, INotification
    {
        public Guid GuidPaymentId { get; init; }
        public ConfirmPayment(Guid billId) : base(DateTime.Now)
        {
            GuidPaymentId = billId;
        }
    }
}

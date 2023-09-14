using Payment.Service.Domain.DomainEvents;
using Payment.Service.Domain.Exceptions;
using Payment.Service.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payment.Service.Domain.Model.Billing
{
    public class Bill : AggregateRoot
    {
        public Guid ClientId { get; private set; }
        public Guid CategoryId { get; private set; }
        public string? Period { get; private set; }
        public BillState State { get; private set; }
        public AmountBill Amount { get; private set; }

        public Bill(Guid clientId, Guid categoryId, string period, decimal amount)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            CategoryId = categoryId;
            Period = period;
            State = BillState.Pending;
            Amount = amount;
        }

        public void Confirmar()
        {
            if (State != BillState.Pending)
            {
                throw new ConfirmationBillException("La transaccion esta en estado: " + State.ToString());
            }
            State = BillState.Paid;
            ConfirmPayment evento = new ConfirmPayment(Id);
            AddDomainEvent(evento);
        }

        public void Edit(string period)
        {
            Period = period;
        }

        private Bill() { }
    }
}

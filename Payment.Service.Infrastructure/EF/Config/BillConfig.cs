using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment.Service.Domain.Model.Billing;
using Payment.Service.Domain.Model.Category;
using Payment.Service.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Config
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("bill");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("billId");

            builder.Property(x => x.Period)
            .HasColumnName("period");

            var typeConverter = new ValueConverter<BillState, string>(
                enumValueType => enumValueType.ToString(),
                type => (BillState)Enum.Parse(typeof(BillState), type)
            );

            builder.Property(x => x.State)
             .HasConversion(typeConverter)
             .HasColumnName("state")
             .HasMaxLength(20)
             .IsRequired();

            var amountConverter = new ValueConverter<AmountBill, decimal>(
                amountValue => amountValue.Value,
                amount => new AmountBill(amount));

            builder.Property(x => x.Amount)
                .HasColumnName("amount")
                .HasConversion(amountConverter);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}

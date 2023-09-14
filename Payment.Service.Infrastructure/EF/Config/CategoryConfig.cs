using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment.Service.Domain.Model.Category;
using Payment.Service.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("categoryId");

            var nameConverter = new ValueConverter<NameValue, string>(
                nameValue => nameValue.Value,
                name => new NameValue(name)
            );

            builder.Property(x => x.Name)
            .HasConversion(nameConverter)
            .HasColumnName("name");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Payment.Service.Domain.Model.Billing;
using Payment.Service.Domain.Model.Category;
using Payment.Service.Domain.Model.Client;
using Payment.Service.Infrastructure.EF.Config;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Contexts
{
    public class WriteDBContext : DbContext
    {
        public virtual DbSet<Client> Client { set; get; }
        public virtual DbSet<Category> Category { set; get; }
        public virtual DbSet<Bill> Bill { set; get; }

        public WriteDBContext(DbContextOptions<WriteDBContext> options) : base(options)
        {
            Database.EnsureCreated();
            Seed();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var clientConfig = new ClientConfig();
            modelBuilder.ApplyConfiguration<Client>(clientConfig);

            var categoryConfig = new CategoryConfig();
            modelBuilder.ApplyConfiguration<Category>(categoryConfig);

            var billConfig = new BillConfig();
            modelBuilder.ApplyConfiguration<Bill>(billConfig);

            modelBuilder.Ignore<DomainEvent>();
            //Client client = new Client("Client1");


            //modelBuilder.Entity<Client>().HasData(client);
        }

        public void Seed()
        {
            Client client1 = new Client("Joseph Carlton");
            Client client2 = new Client("Maria Juarez");
            Client client3 = new Client("Albert Kenny");
            Client client4 = new Client("Jessica Phillips");
            Client client5 = new Client("Charles Johnson");
            this.AddRange(client1, client2, client3, client4,client5);
            //this.SaveChanges();
        }
    }
}

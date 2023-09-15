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
            
        }

        public void Seed()
        {
            Client client1 = new Client("Joseph Carlton");
            Client client2 = new Client("Maria Juarez");
            Client client3 = new Client("Albert Kenny");
            Client client4 = new Client("Jessica Phillips");
            Client client5 = new Client("Charles Johnson");
            this.AddRange(client1, client2, client3, client4,client5);

            Category cat1 = new Category("WATER");
            Category cat2 = new Category("SEWER");
            Category cat3 = new Category("ELECTICITY");
            this.AddRange(cat1, cat2, cat3);

            Bill bill1 = new Bill(client1.Id, cat1.Id, "202001", 100);
            Bill bill2 = new Bill(client1.Id, cat3.Id, "202002", 200);

            Bill bill3 = new Bill(client2.Id, cat2.Id, "202001", 50);
            Bill bill4 = new Bill(client2.Id, cat1.Id, "202002", 150);

            Bill bill5 = new Bill(client3.Id, cat3.Id, "202003", 250);
            Bill bill6 = new Bill(client3.Id, cat1.Id, "202004", 300);

            Bill bill7 = new Bill(client4.Id, cat1.Id, "202005", 300);
            Bill bill8 = new Bill(client4.Id, cat2.Id, "202006", 150);

            Bill bill9 = new Bill(client5.Id, cat2.Id, "202007", 125);
            Bill bill10 = new Bill(client5.Id, cat3.Id, "202008", 90);
            this.AddRange(bill1, bill2, bill3, bill4, bill5, bill6, bill7, bill8, bill9, bill10);
            //this.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Payment.Service.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.Config
{
    public class ReadDBContext : DbContext
    {
        public virtual DbSet<ClientReadModel> Client { set; get; }
        public virtual DbSet<CategoryReadModel> Category { set; get; }
        public virtual DbSet<BillReadModel> Bill { set; get; }
        public ReadDBContext(DbContextOptions<ReadDBContext> options) : base(options)
        {
        }

        public ReadDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

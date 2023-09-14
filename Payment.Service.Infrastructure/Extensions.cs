using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Service.Application;
using Payment.Service.Domain.Repositories;
using Payment.Service.Infrastructure.EF.Contexts;
using Payment.Service.Infrastructure.EF.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            AddDatabase(services, configuration, isDevelopment);
            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString =
                    configuration.GetConnectionString("PaymentServiceConnection");
            services.AddDbContext<ReadDBContext>(context =>
                    context.UseSqlite(connectionString));
            services.AddDbContext<WriteDBContext>(context =>
                context.UseSqlite(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBillRepository, BillRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDBContext>();
                context.Database.Migrate();
            }
        }
    }
}

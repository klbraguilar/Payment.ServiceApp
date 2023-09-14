using Microsoft.Extensions.DependencyInjection;
using Payment.Service.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<ICategoryFactory, CategoryFactory>();
            services.AddSingleton<IClientFactory, ClientFactory>();
            services.AddSingleton<IBillFactory, BillFactory>();
            return services;
        }
    }
}

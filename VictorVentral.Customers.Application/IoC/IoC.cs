using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Customers.Application.Customers.Interfaces;
using VictorVentral.Customers.Application.Customers.Services;

namespace VictorVentral.Customers.Application.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerService, CustomerService>();
        }
    }
}

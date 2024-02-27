using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Customers.Domain.Interfaces.Repositories.Customers;
using VictorVentral.Customers.Infrastructure.Repositories.Customers;

namespace VictorVentral.Customers.Infrastructure.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}

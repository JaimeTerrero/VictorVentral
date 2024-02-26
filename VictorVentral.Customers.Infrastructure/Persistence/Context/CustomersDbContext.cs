using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentral.Customers.Infrastructure.Persistence.Context
{
    public interface ICustomersDbContext : IDbContext {}
    
    public class CustomersDbContext : DbContext 
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) {}
    }
}

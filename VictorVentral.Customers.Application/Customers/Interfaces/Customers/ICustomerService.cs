using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Customers.Application.Customers.DTOs;
using VictorVentral.Customers.Domain.Entities;

namespace VictorVentral.Customers.Application.Customers.Interfaces.Customers
{
    public interface ICustomerService : IService<Customer, CustomerDto>
    {
    }
}

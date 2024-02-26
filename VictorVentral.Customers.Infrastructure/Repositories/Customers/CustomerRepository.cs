using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Customers.Domain.Entities;
using VictorVentral.Customers.Domain.Interfaces.Repositories.Customers;
using VictorVentral.Customers.Infrastructure.Persistence.Context;

namespace VictorVentral.Customers.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomersDbContext _customersDbContext;

        public CustomerRepository(CustomersDbContext customersDbContext)
        {
            _customersDbContext = customersDbContext;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _customersDbContext.Customers.AddAsync(customer);
            await _customersDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _customersDbContext.Customers.FindAsync(id);
            _customersDbContext.Set<Customer>().Remove(customer);
            await _customersDbContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customersDbContext.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customersDbContext.Set<Customer>().FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _customersDbContext.Entry(customer).State = EntityState.Modified;
            await _customersDbContext.SaveChangesAsync();
        }
    }
}

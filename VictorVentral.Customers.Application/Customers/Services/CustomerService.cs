using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Customers.Application.Customers.DTOs;
using VictorVentral.Customers.Application.Customers.Interfaces.Customers;
using VictorVentral.Customers.Domain.Entities;
using VictorVentral.Customers.Domain.Interfaces.Repositories.Customers;

namespace VictorVentral.Customers.Application.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> Add(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        public async Task Delete(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<List<Customer>> GetAll()
        {
            var customerList = await _customerRepository.GetAllAsync();

            return customerList;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            Customer cstmr = new();
            cstmr.Id = customer.Id;
            cstmr.Name = customer.Name;
            cstmr.Lastname = customer.Lastname;
            cstmr.Email = customer.Email;
            cstmr.Address = customer.Address;
            cstmr.PhoneNumber = customer.PhoneNumber;
            cstmr.RegisteredDate = customer.RegisteredDate;
            cstmr.RegisteredPurchase = customer.RegisteredPurchase;

            return cstmr;
        }

        public async Task Update(int id, CustomerDto customerDto)
        {
            Customer customer = await _customerRepository.GetByIdAsync(id);

            _mapper.Map(customerDto, customer);

            await _customerRepository.UpdateAsync(customer);
        }
    }
}

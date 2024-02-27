using Microsoft.AspNetCore.Mvc;
using VictorVentral.Customers.Application.Customers.DTOs;
using VictorVentral.Customers.Application.Customers.Interfaces;

namespace VictorVentral.Customers.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult> GetAllCustomers()
        {
            var customer = await _customerService.GetAll();

            return Ok(customer);
        }

        [HttpPost("CreateCustomer")] 
        public async Task<ActionResult> CreateCustomer(CustomerDto customerDto)
        {
            var customer = await _customerService.Add(customerDto);

            return Ok(customer);
        }

        [HttpGet("GetCustomerById/{id:int}")]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetById(id);

            return Ok(customer);
        }

        [HttpPut("UpdateCustomer/{id:int}")]
        public async Task<ActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            await _customerService.Update(id, customerDto);

            return NoContent();
        }

        [HttpDelete("DeleteCustomer/{id:int}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.Delete(id);

            return NoContent();
        }
    }
}

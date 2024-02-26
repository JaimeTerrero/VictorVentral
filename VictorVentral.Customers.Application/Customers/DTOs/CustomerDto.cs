using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentral.Customers.Application.Customers.DTOs
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime RegisteredPurchase { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Job.Customer.ExecuteCustomer.Models.Response
{
    public class CustomersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public decimal Salary { get; set; }
    }
}

using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataModel;

namespace Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        public CustomerService() { }

        public CustomerResponse GetCustomer()
        {
            var response =  new CustomerResponse();
            response.Name = "abcd";
            response.Email = "abcd@emil.com";
            response.Phone = "1234567890";
            response.Address = "H11 abcd India";
            return response;

        }
    }
}

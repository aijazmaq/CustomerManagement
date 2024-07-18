using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataModel;
using Infrastructure.DBContext;
using Domain.Customer;
using System.Collections.Immutable;

namespace Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly DataBaseContext _context;
        public CustomerService(DataBaseContext context)
        {
            _context = context;
        }

        public CustomerResponse GetCustomer()
        {
            var response =  new CustomerResponse();
            response.Name = "abcd";
            response.Email = "abcd@emil.com";
            response.Phone = "1234567890";
            response.Address = "H11 abcd India";
            return response;

        }

        public IEnumerable<CustomerResponse> GetCustomerList()
        {
            var response = _context.customers;
            var result = (from customer in response
                          select new CustomerResponse
                          {
                              Name = customer.Name, 
                              Email = customer.Email,
                              Phone = customer.Phone,
                              Address = customer.Address

                          }).ToList();
              
            return result;

        }

        public int SaveCustomer(CustomerRequest customerRequest)
        {
            var request = new Customer();
            request.Name = customerRequest.Name;
            request.Email = customerRequest.Email;
            request.Phone = customerRequest.Phone;
            request.Address = customerRequest.Address;
            _context.customers.Add(request);
            return _context.SaveChanges();
        }
    }
}

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
using Microsoft.EntityFrameworkCore;

namespace Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly DataBaseContext _context;
        public CustomerService(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerResponse> GetCustomer(CustomerRequest customerRequest)
        {
            var responsefromTable = _context.customers.Where(xx=> xx.Name == customerRequest.Name);
            var result = (from xx in responsefromTable
                          select new CustomerResponse
                          {
                              Name = xx.Name,
                              Email = xx.Email,
                              Phone = xx.Phone,
                              Address = xx.Address

                          }).ToList();

            return result;


        }

        public IEnumerable<CustomerResponse> GetCustomerList()
        {
            var responsefromTable = _context.customers;
            var result = (from xx in responsefromTable
                          select new CustomerResponse
                          {
                              Name = xx.Name, 
                              Email = xx.Email,
                              Phone = xx.Phone,
                              Address = xx.Address

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
           // _context.Database.ExecuteSqlRaw("procedure @param1{0},@param1{1}", customerRequest.Name, customerRequest.Phone);
            return _context.SaveChanges();
        }
    }
}

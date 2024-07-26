using Service.Interface;
using Infrastructure.DataModel;
using Infrastructure.DBContext;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
            var responsefromTable = _context.customer.Where(xx => xx.Name == customerRequest.Name);
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
            var responsefromTable = _context.customer;
            var result = (from xx in responsefromTable
                          select new CustomerResponse
                          {
                              CustomerId = xx.CustomerId,
                              Name = xx.Name,
                              Email = xx.Email,
                              Phone = xx.Phone,
                              Address = xx.Address

                          }).ToList();

            return result;



        }

        public int SaveCustomer(CustomerRequest customerRequest)
        {
            /// saving data via entity framwork itself
            //var request = new Customer();
            //request.Name = customerRequest.Name;
            //request.Email = customerRequest.Email;
            //request.Phone = customerRequest.Phone;
            //request.Address = customerRequest.Address;
            //_context.customer.Add(request);
            // return _context.SaveChanges();

            /// saving data via store procedure 
            var sql = "SaveCustomer @Name, @Phone, @Email, @Address";
            var parameters = new[]
            {
                new SqlParameter("@Name", customerRequest.Name),
                new SqlParameter("@Phone", customerRequest.Phone),
                new SqlParameter("@Email", customerRequest.Email),
                new SqlParameter("@Address", customerRequest.Address)
            };

            return _context.Database.ExecuteSqlRaw(sql, parameters);

        }

        public int UpdateCustomer(CustomerRequest customerRequest)
        {
            //update via entity fromwork 
            //var request = new Customer();
            //request.CustomerId = customerRequest.CustomerId;
            //request.Name = customerRequest.Name;
            //request.Email = customerRequest.Email;
            //request.Phone = customerRequest.Phone;
            //request.Address = customerRequest.Address;
            //_context.customer.Update(request);
            //return _context.SaveChanges();

            //update via store procedure 
            var sql = "UpdateCustomer @CustomerId, @Name, @Phone, @Email, @Address";
            var parameters = new[]
            {
                new SqlParameter("@CustomerId",customerRequest.CustomerId),
                new SqlParameter("@Name", customerRequest.Name),
                new SqlParameter("@Phone", customerRequest.Phone),
                new SqlParameter("@Email", customerRequest.Email),
                new SqlParameter("@Address", customerRequest.Address)
            };

            return _context.Database.ExecuteSqlRaw(sql, parameters);

        }

        public IEnumerable<CustomerResponse> GetCustomerListByProc()
        {

            var sql = "GetCustomer";
            var parameters = new[]
            {
                new SqlParameter()
            };

            var data = _context.customer.FromSqlRaw(sql).ToList();
            var result = (from xx in data
                          select new CustomerResponse
                          {
                              CustomerId = xx.CustomerId,
                              Name = xx.Name,
                              Email = xx.Email,
                              Phone = xx.Phone,
                              Address = xx.Address

                          }).ToList();

            return result;



        }
    }
}

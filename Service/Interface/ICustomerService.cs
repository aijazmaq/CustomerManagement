using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataModel;

namespace Service.Interface
{
    public interface ICustomerService
    {
        public CustomerResponse GetCustomer();
        public IEnumerable<CustomerResponse> GetCustomerList();
        public int SaveCustomer(CustomerRequest customer);
    }
}

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
        public IEnumerable<CustomerResponse> GetCustomer(CustomerRequest customerRequest);
        public IEnumerable<CustomerResponse> GetCustomerList();
        public IEnumerable<CustomerResponse> GetCustomerListByProc();
        public int SaveCustomer(CustomerRequest customer);

        public int UpdateCustomer(CustomerRequest customer);
    }
}

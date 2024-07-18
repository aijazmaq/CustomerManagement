using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Implementation;
using Infrastructure.DataModel;

namespace CustomerManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController (ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomer")]
        public CustomerResponse GetCustomer(CustomerRequest customerRequest)
        {

            return _customerService.GetCustomer();
        }

        [HttpGet("GetCustomerList")]
        public IEnumerable<CustomerResponse> GetCustomersList()
        {
            return _customerService.GetCustomerList();
        }

        [HttpPost("SaveCustomer")]
        public int SaveCustomer(CustomerRequest customerRequest) 
        {
            return _customerService.SaveCustomer(customerRequest);
        }
    }
}

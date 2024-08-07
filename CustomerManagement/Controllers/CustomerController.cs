using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Implementation;
using Infrastructure.DataModel;
using System.ComponentModel.DataAnnotations;

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

        [HttpPost("GetCustomer")]
        public IEnumerable<CustomerResponse> GetCustomer(CustomerRequest customerRequest)
        {

            return _customerService.GetCustomer(customerRequest);
        }


        [HttpGet("GetCustomerByParam/{name}/{value}")]
        public IActionResult GetCustomerByParam(string name,int value)
        {

            return Ok(_customerService.GetCustomerByParam(name));
        }



        //[HttpGet("GetCustomerList")]
        //public IEnumerable<CustomerResponse> GetCustomersList()
        //{
        //    return _customerService.GetCustomerList();
        //}

        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomersList()
        {
            var result =  _customerService.GetCustomerList();
            return Ok(result);
        }

        [HttpPost("SaveCustomer")]
        public IActionResult SaveCustomer(CustomerRequest customerRequest) 
        {
            var customValidation = new CustomerRequestValidtion();
            var validResult = customValidation.Validate(customerRequest);
            if (!validResult.IsValid)
            { 
                return BadRequest(validResult.Errors);
            }
            return  Ok(_customerService.SaveCustomer(customerRequest));
        }

        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(CustomerRequest customerRequest)
        {
       
            return Ok(_customerService.UpdateCustomer(customerRequest));
        }

        
        [HttpGet("GetCustomerListByProc")]
        public IActionResult GetCustomerListByProc()
        {
            return Ok(_customerService.GetCustomerListByProc());
        }
    }
}

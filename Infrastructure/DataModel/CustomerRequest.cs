using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;  

namespace Infrastructure.DataModel
{
    public class CustomerRequest
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }

    public class CustomerRequestValidtion : AbstractValidator<CustomerRequest>
    {
        
        public CustomerRequestValidtion() 
        {
            RuleFor(xx=> xx.CustomerId).NotEmpty().WithMessage("Customer id can not be null, Please provide valid value.");
            RuleFor(xx => xx.Name).NotEmpty().WithMessage("Name can not be empty.");
            RuleFor(xx => xx.Name).Length(5, 30).WithMessage("For name min length is 5 and max is 30");
        }
    }




}

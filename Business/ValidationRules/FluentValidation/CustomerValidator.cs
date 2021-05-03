using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cst => cst.CompanyName).NotEmpty();
            RuleFor(cst => cst.CompanyName).MinimumLength(2);
            RuleFor(cst => cst.UserId).NotEmpty();
        }
    }
}

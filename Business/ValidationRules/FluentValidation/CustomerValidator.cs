using Business.Constants.Messages;
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
            RuleFor(cu => cu.CompanyName).NotEmpty().WithMessage(CustomerMessages.CompanyNameCannotBeEmpty);
            RuleFor(cu => cu.CompanyName).MinimumLength(2).WithMessage(CustomerMessages.CompanyNameInvalid);
            RuleFor(cu => cu.CompanyName).Matches(@"^[a-zA-Z0-9\-']*$").WithMessage(CustomerMessages.CompanyNameInvalid);

            RuleFor(cu => cu.ContactName).NotEmpty().WithMessage(CustomerMessages.ContactNameCannotBeEmpty);
            RuleFor(cu => cu.ContactName).MinimumLength(2).WithMessage(CustomerMessages.ContactNameInvalid);
            RuleFor(cu => cu.ContactName).Matches(@"^[a-zA-Z-']*$").WithMessage(CustomerMessages.ContactNameInvalid);

            RuleFor(cu => cu.CustomerCity).NotEmpty().WithMessage(CustomerMessages.CustomerCityCannotBeEmpty);
            RuleFor(cu => cu.CustomerCity).Matches(@"^[a-zA-Z-']*$").WithMessage(CustomerMessages.CustomerCityInvalid);


        }
    }
}

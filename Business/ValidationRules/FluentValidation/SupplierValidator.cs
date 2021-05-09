using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(s => s.SupplierCompanyName).NotEmpty().WithMessage(SupplierMessages.SupplierCompanyNameCannotBeEmpty);
            RuleFor(s => s.SupplierCompanyName).MinimumLength(2).WithMessage(SupplierMessages.SupplierCompanyNameInvalid);
            RuleFor(s => s.SupplierCompanyName).Matches(@"^[a-zA-Z0-9\-']*$").WithMessage(SupplierMessages.SupplierCompanyNameInvalid);

            RuleFor(s => s.SupplierContactName).NotEmpty().WithMessage(SupplierMessages.SupplierContactNameCannotBeEmpty);
            RuleFor(s => s.SupplierContactName).MinimumLength(2).WithMessage(SupplierMessages.SupplierContactNameInvalid);
            RuleFor(s => s.SupplierContactName).Matches(@"^[a-zA-Z0-9\-']*$").WithMessage(SupplierMessages.SupplierContactNameInvalid);

            RuleFor(s => s.SupplierCity).NotEmpty().WithMessage(SupplierMessages.SupplierCityCannotBeEmpty);
            RuleFor(s => s.SupplierCity).MinimumLength(2).WithMessage(SupplierMessages.SupplierCityInvalid);
            RuleFor(s => s.SupplierCity).Matches(@"^[a-zA-Z-']*$").WithMessage(SupplierMessages.SupplierCityInvalid);
        }
    }
}

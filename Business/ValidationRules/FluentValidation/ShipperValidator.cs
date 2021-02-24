using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ShipperValidator : AbstractValidator<Shipper>
    {
        public ShipperValidator()
        {
            RuleFor(sh => sh.ShipCompanyName).NotEmpty().WithMessage(ShipperMessages.ShipperCompanyNameCannotBeEmpty);
            RuleFor(sh => sh.ShipCompanyName).MinimumLength(2).WithMessage(ShipperMessages.ShipperCompanyNameInvalid);
            RuleFor(sh => sh.ShipCompanyPhone).NotEmpty().WithMessage(ShipperMessages.ShipCompanyPhoneCannotBeEmpty);
            RuleFor(sh => sh.ShipCompanyPhone).Length(10).WithMessage(ShipperMessages.ShipCompanyPhoneLength);
        }
    }
}

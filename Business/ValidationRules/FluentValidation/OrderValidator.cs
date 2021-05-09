using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.OrderDate).NotEmpty().WithMessage(OrderMessages.OrderDateCannotBeEmpty); 
            
            RuleFor(o => o.ShipName).NotEmpty().WithMessage(OrderMessages.ShipNameCannotBeEmpty); 
            RuleFor(o => o.ShipName).MinimumLength(2).WithMessage(OrderMessages.ShipNameInvalid);
            RuleFor(o => o.ShipName).Matches(@"^[a-zA-Z0-9\-']*$").WithMessage(OrderMessages.ShipNameInvalid);

            RuleFor(o => o.ShipCountry).NotEmpty().WithMessage(OrderMessages.ShipCountryCannotBeEmpty); 
            RuleFor(o => o.ShipCountry).MinimumLength(2).WithMessage(OrderMessages.ShipCountryInvalid);
            RuleFor(o => o.ShipCountry).Matches(@"^[a-zA-Z-']*$").WithMessage(OrderMessages.ShipCountryInvalid);

            RuleFor(o => o.ShipCity).NotEmpty().WithMessage(OrderMessages.ShipCityCannotBeEmpty); 
            RuleFor(o => o.ShipCity).MinimumLength(2).WithMessage(OrderMessages.ShipCityInvalid);
            RuleFor(o => o.ShipCity).Matches(@"^[a-zA-Z-']*$").WithMessage(OrderMessages.ShipCityInvalid);

        }
    }
}

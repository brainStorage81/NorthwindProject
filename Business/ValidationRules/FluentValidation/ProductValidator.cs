using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage(ProductMessages.ProductNameCannotBeEmpty);
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage(ProductMessages.ProductNameInvalid);
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage(ProductMessages.QuantityPerUnitCannotBeEmpty);
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage(ProductMessages.UnitPriceCannotBeEmpty);
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage(ProductMessages.UnitPriceCannotBeNegativeValue);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1)
                .WithMessage(ProductMessages.UnitPriceInvalidGreaterThanOrEqualTo);            
        }
    }
}

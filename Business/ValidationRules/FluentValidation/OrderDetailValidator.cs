using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(od => od.PiecePrice).NotEmpty().WithMessage(OrderDetailMessages.UnitPriceCannotBeEmpty);
            RuleFor(od => od.PiecePrice).GreaterThan(0).WithMessage(OrderDetailMessages.UnitPriceCannotBeNegativeValue); ;          
            RuleFor(od => od.Amount).NotEmpty().WithMessage(OrderDetailMessages.QuantityCannotBeEmpty);            
            RuleFor(od => od.Discount).GreaterThan(0).WithMessage(OrderDetailMessages.DiscountCannotBeNegativeValue);
        }
    }
}

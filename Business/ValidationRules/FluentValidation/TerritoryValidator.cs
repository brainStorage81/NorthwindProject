using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class TerritoryValidator : AbstractValidator<Territory>
    {
        public TerritoryValidator()
        {
            RuleFor(t => t.TerritoryDescription).NotEmpty().WithMessage(TerritoryMessages.TerritoryDescriptionCannotBeEmpty);
        }
    }
}

using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(r => r.RegionDescription).NotEmpty().WithMessage(RegionMessages.RegionDescriptionCannotBeEmpty);
            RuleFor(r => r.RegionDescription).Matches(@"^[a-zA-Z0-9\-']*$").WithMessage(RegionMessages.RegionDescriptionInvalid);
        }
    }
}

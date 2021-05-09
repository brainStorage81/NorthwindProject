using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage(CategoryMessages.CategoryNameCannotBeEmpty);
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage(CategoryMessages.CategoryNameInvalid);
            RuleFor(c => c.CategoryName).Matches(@"^[a-zA-Z-']*$").WithMessage(CategoryMessages.CategoryNameInvalid);

            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage(CategoryMessages.CategoryDescriptionCannotBeEmpty);
            RuleFor(c => c.CategoryDescription).Matches(@"^[a-zA-Z0-9\-']*$").WithMessage(CategoryMessages.CategoryDescriptionInvalid); 
        }
    }
}

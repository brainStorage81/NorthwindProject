using Business.Constants.Messages;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(UserMessages.UserFirsNameCannotBeEmpty);
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage(UserMessages.UserFirsNameInvalid);
            RuleFor(u => u.FirstName).Matches(@"^[a-zA-Z-']*$").WithMessage(UserMessages.UserFirsNameInvalid);

            RuleFor(u => u.LastName).NotEmpty().WithMessage(UserMessages.UserLastNameCannotBeEmpty);
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage(UserMessages.UserLastNameInvalid);
            RuleFor(u => u.LastName).Matches(@"^[a-zA-Z-']*$").WithMessage(UserMessages.UserLastNameInvalid);

            RuleFor(u => u.Email).NotEmpty().WithMessage(UserMessages.UserEmailCannotBeEmpty);
            RuleFor(u => u.Email).MinimumLength(2).WithMessage(UserMessages.UserEmailInvalid);
            RuleFor(u => u.Email).EmailAddress().WithMessage(UserMessages.UserEmailInvalid);
        }   
    }

}

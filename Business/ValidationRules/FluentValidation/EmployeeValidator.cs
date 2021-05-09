using Business.Constants.Messages;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.EmployeeFirsName).NotEmpty().WithMessage(EmployeeMessages.FirstNameCannotBeEmpty);
            RuleFor(e => e.EmployeeFirsName).MinimumLength(2).WithMessage(EmployeeMessages.FirstNameInvalid);
            RuleFor(e => e.EmployeeFirsName).Matches(@"^[a-zA-Z-']*$").WithMessage(EmployeeMessages.FirstNameInvalid);

            RuleFor(e => e.EmployeeLastName).NotEmpty().WithMessage(EmployeeMessages.LastNameCannotBeEmpty);
            RuleFor(e => e.EmployeeLastName).MinimumLength(2).WithMessage(EmployeeMessages.LastNameInvalid);
            RuleFor(e => e.EmployeeLastName).Matches(@"^[a-zA-Z-']*$").WithMessage(EmployeeMessages.LastNameInvalid);

            RuleFor(e => e.EmployeeCity).NotEmpty().WithMessage(EmployeeMessages.EmployeeCityCannotBeEmpty);
            RuleFor(e => e.EmployeeCity).MinimumLength(2).WithMessage(EmployeeMessages.EmployeeCityInvalid);
            RuleFor(e => e.EmployeeCity).Matches(@"^[a-zA-Z-']*$").WithMessage(EmployeeMessages.EmployeeCityInvalid);

        }
    }
}

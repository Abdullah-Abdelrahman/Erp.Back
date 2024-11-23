using Name.Core.Features.UserBase.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.UserBase.Commands.Validations
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserValidator()
        {
            ValidationRules();
        }
        public void ValidationRules()
        {




            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value")
                .EmailAddress().WithMessage("Must be a valid Email");

            RuleFor(x => x.UserName).NotNull().WithMessage("UserName must not be null").NotEmpty().WithMessage("UserName must has value");



            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("PhoneNumber must not be null").NotEmpty().WithMessage("PhoneNumber must has value");




        }
    }
}

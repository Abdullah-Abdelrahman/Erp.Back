using Name.Core.Features.UserBase.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.UserBase.Commands.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            ValidationRules();
        }
        public void ValidationRules()
        {



            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value")
                .EmailAddress().WithMessage("Must be a valid Email");

            RuleFor(x => x.Password).NotNull().WithMessage("Password must not be null").NotEmpty().WithMessage("Password must has value");

            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("ConfirmPassword must not be null").NotEmpty().WithMessage("ConfirmPassword must has value").Equal(x => x.Password).WithMessage("two Passwords must be equal");


            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("PhoneNumber must not be null").NotEmpty().WithMessage("PhoneNumber must has value");

        }
    }
}

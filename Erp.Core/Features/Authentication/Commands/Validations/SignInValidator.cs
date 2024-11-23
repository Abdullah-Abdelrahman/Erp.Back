using Name.Core.Features.Authentication.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.Authentication.Commands.Validations
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        public SignInValidator()
        {
            ValidationRules();
        }

        public void ValidationRules()
        {


            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value")
                .EmailAddress().WithMessage("Must be a valid Email");

            RuleFor(x => x.Password).NotNull().WithMessage("Password must not be null").NotEmpty().WithMessage("Password must has value");

        }
    }
}

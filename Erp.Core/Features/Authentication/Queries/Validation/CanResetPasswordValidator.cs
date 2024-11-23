using Name.Core.Features.Authentication.Queries.Models;
using FluentValidation;

namespace Name.Core.Features.Authentication.Queries.Validation
{
    public class CanResetPasswordValidator : AbstractValidator<CanResetPasswordQuery>
    {
        public CanResetPasswordValidator()
        {
            ValidationRules();
        }

        public void ValidationRules()
        {


            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value")
                .EmailAddress().WithMessage("Must be a valid Email");

            RuleFor(x => x.code).NotNull().WithMessage("code must not be null").NotEmpty().WithMessage("code must has value");

        }
    }
}

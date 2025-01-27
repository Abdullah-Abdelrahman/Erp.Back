using Name.Core.Features.Authentication.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.Authentication.Commands.Validations
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {

        public ResetPasswordValidator()
        {
            ValidationRules();
        }

        public void ValidationRules()
        {


            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value")
                .EmailAddress().WithMessage("Must be a valid Email");



        }
    }
}

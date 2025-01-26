using Name.Core.Features.UserBase.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.UserBase.Commands.Validations
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordValidator()
        {
            ValidationRules();
        }
        public void ValidationRules()
        {


            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value");



            RuleFor(x => x.NewPassword).NotNull().WithMessage("New Password must not be null").NotEmpty().WithMessage("new Password must has value");

            RuleFor(x => x.NewConfirmPassword).NotNull().WithMessage("ConfirmPassword must not be null").NotEmpty().WithMessage("ConfirmPassword must has value").Equal(x => x.NewPassword).WithMessage("two Passwords must be equal");
        }


    }
}

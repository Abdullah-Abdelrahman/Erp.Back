using Name.Core.Features.Authentication.Queries.Models;
using FluentValidation;

namespace Name.Core.Features.Authentication.Queries.Validation
{
    public class ConfirmEmailValidation : AbstractValidator<ConfirmEmailQuery>
    {
        public ConfirmEmailValidation()
        {
            ValidationRules();
        }
        public void ValidationRules()
        {



            RuleFor(x => x.userId).NotNull().WithMessage("userId must not be null").NotEmpty().WithMessage("userId must has value");

            RuleFor(x => x.code).NotNull().WithMessage("code must not be null").NotEmpty().WithMessage("code must has value");



        }
    }
}

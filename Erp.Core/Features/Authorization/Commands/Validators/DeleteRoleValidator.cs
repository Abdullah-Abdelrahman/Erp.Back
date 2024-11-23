using Name.Core.Features.Authorization.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.Authorization.Commands.Validators
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {

        public DeleteRoleValidator()
        {
            ValidationRules();
        }
        public void ValidationRules()
        {
            RuleFor(x => x.RoleId).NotNull().WithMessage("RoleId must not be null").NotEmpty().WithMessage("RoleId must has value");

        }
    }
}

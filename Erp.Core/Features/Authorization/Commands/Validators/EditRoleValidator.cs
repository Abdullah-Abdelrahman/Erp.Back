using Name.Core.Features.Authorization.Commands.Models;
using FluentValidation;

namespace Name.Core.Features.Authorization.Commands.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {

        public EditRoleValidator()
        {
            ValidationRules();
        }

        public void ValidationRules()
        {




            RuleFor(x => x.RoleName).NotNull().WithMessage("RoleName must not be null").NotEmpty().WithMessage("RoleName must has value");

            RuleFor(x => x.RoleId).NotNull().WithMessage("RoleId must not be null").NotEmpty().WithMessage("RoleId must has value");





        }
    }
}

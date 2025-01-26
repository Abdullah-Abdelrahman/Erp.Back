using Name.Core.Features.Authorization.Commands.Models;
using Name.Service.Abstracts;
using FluentValidation;

namespace Name.Core.Features.Authorization.Commands.Validators
{
    public class AddRoleValidators : AbstractValidator<AddRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;
        public AddRoleValidators(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            ValidationRules();
        }

        public void ValidationRules()
        {


            RuleFor(x => x.RoleName).NotNull().WithMessage("RoleName must not be null").NotEmpty().WithMessage("RoleName must has value");

            RuleFor(x => x.RoleName).MustAsync(async (Key, CancellationToken) => (await _authorizationService.IsRoleExistByName(Key)) == false).WithMessage("Role is in the system before!!");

        }

    }
}

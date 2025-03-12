using Erp.Core.Features.Module.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Module.Commands.Validations
{
  public class DeleteModuleValidator : AbstractValidator<DeleteModuleCommand>
  {
    #region
    public DeleteModuleValidator()
    {
      ValidationRules();
      CustomValidationRules();
    }
    #endregion
    private void CustomValidationRules()
    {

    }



    public void ValidationRules()
    {
      RuleFor(x => x.ModuleId).NotNull().WithMessage("ModuleId must not be null").NotEmpty().WithMessage("ModuleId must has value");


    }
  }
}

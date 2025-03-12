using Erp.Core.Features.Module.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Module.Commands.Validations
{
  public class AddModuleValidator : AbstractValidator<AddModuleCommand>
  {
    #region
    public AddModuleValidator()
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
      RuleFor(x => x.Name).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");
    }
  }
}


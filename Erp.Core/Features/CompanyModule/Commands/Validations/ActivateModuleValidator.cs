using Erp.Core.Features.CompanyModule.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.CompanyModule.Commands.Validations
{
  public class ActivateModuleValidator : AbstractValidator<ActivateModuleCommand>
  {
    #region
    public ActivateModuleValidator()
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
      RuleFor(x => x.ModelId).NotNull().WithMessage("ModelId must not be null").NotEmpty().WithMessage("ModelId must has value");
    }
  }
}


using Erp.Core.Features.CostCenter.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.CostCenter.Commands.Validations
{
  public class AddCostCenterValidator : AbstractValidator<AddCostCenterCommand>
  {
    #region
    public AddCostCenterValidator()
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
      RuleFor(x => x.CostCenterName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");


    }
  }
}

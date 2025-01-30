using Erp.Core.Features.CustomerClassification.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.CustomerClassification.Commands.Validations
{
  public class AddCustomerClassificationValidator : AbstractValidator<AddCustomerClassificationCommand>
  {
    #region
    public AddCustomerClassificationValidator()
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
      RuleFor(x => x.CustomerClassificationName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");
    }
  }
}


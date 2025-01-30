using Erp.Core.Features.CustomerClassification.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.CustomerClassification.Commands.Validations
{
  public class DeleteCustomerClassificationValidator : AbstractValidator<DeleteCustomerClassificationCommand>
  {
    #region
    public DeleteCustomerClassificationValidator()
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
      RuleFor(x => x.CustomerClassificationId).NotNull().WithMessage("CustomerClassificationId must not be null").NotEmpty().WithMessage("CustomerClassificationId must has value");


    }
  }
}

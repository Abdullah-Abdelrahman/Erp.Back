using Erp.Core.Features.ReceiptCategory.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.ReceiptCategory.Commands.Validations
{
  public class AddReceiptCategoryValidator : AbstractValidator<AddReceiptCategoryCommand>
  {
    #region
    public AddReceiptCategoryValidator()
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


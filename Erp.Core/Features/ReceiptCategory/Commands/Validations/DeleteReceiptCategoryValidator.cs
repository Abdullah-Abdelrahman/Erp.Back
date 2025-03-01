using Erp.Core.Features.ReceiptCategory.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.ReceiptCategory.Commands.Validations
{
  public class DeleteReceiptCategoryValidator : AbstractValidator<DeleteReceiptCategoryCommand>
  {
    #region
    public DeleteReceiptCategoryValidator()
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
      RuleFor(x => x.ReceiptCategoryId).NotNull().WithMessage("ReceiptCategoryId must not be null").NotEmpty().WithMessage("ReceiptCategoryId must has value");


    }
  }
}

using Erp.Core.Features.PurchaseReturn.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.PurchaseReturn.Commands.Validations
{
  public class AddPurchaseReturnValidator : AbstractValidator<AddPurchaseReturnCommand>
  {
    #region
    public AddPurchaseReturnValidator()
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


      RuleFor(x => x.SupplierId).NotNull().WithMessage("SupplierId must not be null").NotEmpty().WithMessage("SupplierId must has value");
    }

  }
}

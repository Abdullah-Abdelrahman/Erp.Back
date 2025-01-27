using Erp.Core.Features.PurchaseInvoice.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.PurchaseInvoice.Commands.Validations
{
  public class AddPurchaseInvoiceValidator : AbstractValidator<AddPurchaseInvoiceCommand>
  {
    #region
    public AddPurchaseInvoiceValidator()
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

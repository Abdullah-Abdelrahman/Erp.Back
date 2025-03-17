using Erp.Core.Features.Payment.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Payment.Commands.Validations
{
  public class AddSupplierPaymentValidator : AbstractValidator<AddSupplierPaymentCommand>
  {
    #region
    public AddSupplierPaymentValidator()
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



    }
  }
}

using Erp.Core.Features.ReceivingVoucher.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.ReceivingVoucher.Commands.Validations
{
  public class AddReceivingVoucherValidator : AbstractValidator<AddReceivingVoucherCommand>
  {
    #region
    public AddReceivingVoucherValidator()
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

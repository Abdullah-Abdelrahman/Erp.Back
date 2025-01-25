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
      RuleFor(x => x.WarehouseId).NotNull().WithMessage("WarehouseId must not be null").NotEmpty().WithMessage("WarehouseId must has value");

      RuleFor(x => x.SupplierId).NotNull().WithMessage("SupplierId must not be null").NotEmpty().WithMessage("SupplierId must has value");
    }

  }
}

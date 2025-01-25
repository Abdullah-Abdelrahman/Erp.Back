using Erp.Core.Features.DeliveryVoucher.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.DeliveryVoucher.Commands.Validations
{
  public class AddDeliveryVoucherValidator : AbstractValidator<AddDeliveryVoucherCommand>
  {
    #region
    public AddDeliveryVoucherValidator()
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


    }

  }
}

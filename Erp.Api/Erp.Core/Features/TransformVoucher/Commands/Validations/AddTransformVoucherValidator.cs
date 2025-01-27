using Erp.Core.Features.TransformVoucher.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.TransformVoucher.Commands.Validations
{
  public class AddTransformVoucherValidator : AbstractValidator<AddTransformVoucherCommand>
  {
    #region
    public AddTransformVoucherValidator()
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
      RuleFor(x => x.FromWarehouseId).NotNull().WithMessage("WarehouseId must not be null").NotEmpty().WithMessage("WarehouseId must has value");

      RuleFor(x => x.ToWarehouseId).NotNull().WithMessage("SupplierId must not be null").NotEmpty().WithMessage("SupplierId must has value");
    }

  }
}

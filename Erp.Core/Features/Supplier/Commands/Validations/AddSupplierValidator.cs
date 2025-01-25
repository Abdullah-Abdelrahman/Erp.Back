using Erp.Core.Features.Supplier.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Supplier.Commands.Validations
{
  public class AddSupplierValidator : AbstractValidator<AddSupplierCommand>
  {
    #region
    public AddSupplierValidator()
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
      RuleFor(x => x.SupplierName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");


    }
  }
}

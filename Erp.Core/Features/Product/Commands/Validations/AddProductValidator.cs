using Erp.Core.Features.Product.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Product.Commands.Validations
{
  public class AddProductValidator : AbstractValidator<AddProductCommand>
  {
    #region
    public AddProductValidator()
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
      RuleFor(x => x.ProductName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");


    }
  }
}

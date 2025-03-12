using Erp.Core.Features.PriceList.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.PriceList.Commands.Validations
{
  public class AddPriceListValidator : AbstractValidator<AddPriceListCommand>
  {
    #region
    public AddPriceListValidator()
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
      RuleFor(x => x.PriceListName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");
    }
  }
}


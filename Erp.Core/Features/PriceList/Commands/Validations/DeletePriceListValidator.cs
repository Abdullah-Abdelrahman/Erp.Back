using Erp.Core.Features.PriceList.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.PriceList.Commands.Validations
{
  public class DeletePriceListValidator : AbstractValidator<DeletePriceListCommand>
  {
    #region
    public DeletePriceListValidator()
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
      RuleFor(x => x.PriceListId).NotNull().WithMessage("PriceListId must not be null").NotEmpty().WithMessage("PriceListId must has value");


    }
  }
}

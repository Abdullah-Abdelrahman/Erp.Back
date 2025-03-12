using Erp.Core.Features.StockTaking.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.StockTaking.Commands.Validations
{
  public class AddStockTakingValidator : AbstractValidator<AddStockTakingCommand>
  {
    #region
    public AddStockTakingValidator()
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
      RuleFor(x => x.Date).NotNull().WithMessage("Date must not be null").NotEmpty().WithMessage("Date must has value");
    }
  }
}


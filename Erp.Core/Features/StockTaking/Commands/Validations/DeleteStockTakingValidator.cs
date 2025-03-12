using Erp.Core.Features.StockTaking.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.StockTaking.Commands.Validations
{
  public class DeleteStockTakingValidator : AbstractValidator<DeleteStockTakingCommand>
  {
    #region
    public DeleteStockTakingValidator()
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
      RuleFor(x => x.StockTakingId).NotNull().WithMessage("StockTakingId must not be null").NotEmpty().WithMessage("StockTakingId must has value");


    }
  }
}

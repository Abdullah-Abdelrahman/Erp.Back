using Erp.Core.Features.ExpenseCategory.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.ExpenseCategory.Commands.Validations
{
  public class DeleteExpenseCategoryValidator : AbstractValidator<DeleteExpenseCategoryCommand>
  {
    #region
    public DeleteExpenseCategoryValidator()
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
      RuleFor(x => x.ExpenseCategoryId).NotNull().WithMessage("ExpenseCategoryId must not be null").NotEmpty().WithMessage("ExpenseCategoryId must has value");


    }
  }
}

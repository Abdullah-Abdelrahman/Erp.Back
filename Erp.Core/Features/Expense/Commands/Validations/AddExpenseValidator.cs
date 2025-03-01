using Erp.Core.Features.Expense.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Expense.Commands.Validations
{
  public class AddExpenseValidator : AbstractValidator<AddExpenseCommand>
  {
    #region
    public AddExpenseValidator()
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



    }

  }
}

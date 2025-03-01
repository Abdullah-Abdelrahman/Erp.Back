using Erp.Core.Features.ExpenseCategory.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.ExpenseCategory.Commands.Validations
{
  public class AddExpenseCategoryValidator : AbstractValidator<AddExpenseCategoryCommand>
  {
    #region
    public AddExpenseCategoryValidator()
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
      RuleFor(x => x.Name).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");
    }
  }
}


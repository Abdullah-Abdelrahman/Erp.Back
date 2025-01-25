using Erp.Core.Features.Category.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Category.Commands.Validations
{
  public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
  {
    #region
    public AddCategoryValidator()
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
      RuleFor(x => x.CategoryName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");
    }
  }
}


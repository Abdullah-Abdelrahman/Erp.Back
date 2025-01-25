using Erp.Core.Features.Category.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Category.Commands.Validations
{
  public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
  {
    #region
    public DeleteCategoryValidator()
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
      RuleFor(x => x.CategoryId).NotNull().WithMessage("CategoryId must not be null").NotEmpty().WithMessage("CategoryId must has value");


    }
  }
}

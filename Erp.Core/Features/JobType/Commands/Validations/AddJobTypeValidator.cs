using Erp.Core.Features.JobType.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.JobType.Commands.Validations
{
  public class AddJobTypeValidator : AbstractValidator<AddJobTypeCommand>
  {
    #region
    public AddJobTypeValidator()
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


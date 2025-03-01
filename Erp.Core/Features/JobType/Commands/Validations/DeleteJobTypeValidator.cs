using Erp.Core.Features.JobType.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.JobType.Commands.Validations
{
  public class DeleteJobTypeValidator : AbstractValidator<DeleteJobTypeCommand>
  {
    #region
    public DeleteJobTypeValidator()
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
      RuleFor(x => x.JobTypeId).NotNull().WithMessage("JobTypeId must not be null").NotEmpty().WithMessage("JobTypeId must has value");


    }
  }
}

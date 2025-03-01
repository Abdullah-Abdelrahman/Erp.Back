using Erp.Core.Features.Company.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Company.Commands.Validations
{
  public class AddCompanyValidator : AbstractValidator<AddCompanyCommand>
  {
    #region
    public AddCompanyValidator()
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
      RuleFor(x => x.CompanyName).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");

      RuleFor(x => x.CompanyEmail).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value");

      RuleFor(x => x.Password).NotNull().WithMessage("Password must not be null").NotEmpty().WithMessage("Password must has value");
    }
  }
}

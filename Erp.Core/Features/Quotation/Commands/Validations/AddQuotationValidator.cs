using Erp.Core.Features.Quotation.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Quotation.Commands.Validations
{
  public class AddQuotationValidator : AbstractValidator<AddQuotationCommand>
  {
    #region
    public AddQuotationValidator()
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


      RuleFor(x => x.CustomerID).NotNull().WithMessage("CustomerID must not be null").NotEmpty().WithMessage("CustomerID must has value");
    }

  }
}

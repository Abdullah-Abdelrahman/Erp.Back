using Erp.Core.Features.Invoice.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Invoice.Commands.Validations
{
  public class AddInvoiceValidator : AbstractValidator<AddInvoiceCommand>
  {
    #region
    public AddInvoiceValidator()
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

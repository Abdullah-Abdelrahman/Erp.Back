using Erp.Core.Features.RecurringInvoice.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.RecurringInvoice.Commands.Validations
{
  public class AddRecurringInvoiceValidator : AbstractValidator<AddRecurringInvoiceCommand>
  {
    #region
    public AddRecurringInvoiceValidator()
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


      RuleFor(x => x.CustomerId).NotNull().WithMessage("CustomerID must not be null").NotEmpty().WithMessage("CustomerID must has value");
    }

  }
}

using Erp.Core.Features.CreditNote.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.CreditNote.Commands.Validations
{
  public class AddCreditNoteValidator : AbstractValidator<AddCreditNoteCommand>
  {
    #region
    public AddCreditNoteValidator()
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

using Erp.Core.Features.DebitNote.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.DebitNote.Commands.Validations
{
  public class AddDebitNoteValidator : AbstractValidator<AddDebitNoteCommand>
  {
    #region
    public AddDebitNoteValidator()
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


      RuleFor(x => x.SupplierId).NotNull().WithMessage("SupplierId must not be null").NotEmpty().WithMessage("SupplierId must has value");
    }

  }
}

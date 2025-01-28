using Erp.Core.Features.JournalEntry.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.JournalEntry.Commands.Validations
{
  public class AddJournalEntryValidator : AbstractValidator<AddJournalEntryCommand>
  {
    #region
    public AddJournalEntryValidator()
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



    }

  }
}

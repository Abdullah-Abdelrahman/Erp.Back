using Erp.Core.Features.ContactList.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.ContactList.Commands.Validations
{
  public class AddContactListValidator : AbstractValidator<AddContactListCommand>
  {
    #region
    public AddContactListValidator()
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
      RuleFor(x => x.CustomerId).NotNull().WithMessage("CustomerId must not be null").NotEmpty().WithMessage("CustomerId must has value");


    }
  }
}

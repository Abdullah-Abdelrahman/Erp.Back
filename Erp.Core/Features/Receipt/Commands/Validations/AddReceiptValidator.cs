using Erp.Core.Features.Receipt.Commands.Models;
using FluentValidation;

namespace Erp.Core.Features.Receipt.Commands.Validations
{
  public class AddReceiptValidator : AbstractValidator<AddReceiptCommand>
  {
    #region
    public AddReceiptValidator()
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

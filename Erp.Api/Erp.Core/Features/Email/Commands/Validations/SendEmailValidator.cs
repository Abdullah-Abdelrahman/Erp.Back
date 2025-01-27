using Name.Core.Features.Email.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name.Core.Features.Email.Commands.Validations
{
    public class SendEmailValidator :AbstractValidator<SendEmailCommand>
    {

        #region
        public SendEmailValidator()
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
            RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null").NotEmpty().WithMessage("Email must has value");

            RuleFor(x => x.Message).NotNull().WithMessage("Message must not be null").NotEmpty().WithMessage("Message must has value");
        }
    }
}

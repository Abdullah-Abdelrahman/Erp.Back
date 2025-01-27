using Erp.Data.MetaData;
using MediatR;
using Name.Core.Bases;
using Name.Core.Features.Email.Commands.Models;
using Name.Service.Abstracts;

namespace Name.Core.Features.Email.Commands.Handlers
{
  public class EmailCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
  {

    private readonly IEmailService _emailService;
    public EmailCommandHandler(IEmailService emailService)
    {

      _emailService = emailService;
    }

    public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
      var result = await _emailService.SendEmailAsync(request.Email, request.Message, null);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Success(result);
      }
      else
      {
        return BadRequest<string>();
      }
    }
  }
}

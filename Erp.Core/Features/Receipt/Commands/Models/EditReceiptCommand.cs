using Erp.Data.Dto.Receipt;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Receipt.Commands.Models
{
  public class EditReceiptCommand : UpdateReceiptRequest, IRequest<Response<string>>
  {


  }
}

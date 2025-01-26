using Erp.Data.Dto.PurchaseReturn;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseReturn.Commands.Models
{
  public class AddPurchaseReturnCommand : AddPurchaseReturnRequest, IRequest<Response<string>>
  {

  }
}

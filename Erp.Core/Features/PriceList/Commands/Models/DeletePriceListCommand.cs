using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PriceList.Commands.Models
{
  public class DeletePriceListCommand : IRequest<Response<string>>
  {
    public int PriceListId { get; set; }

    public DeletePriceListCommand(int id)
    {
      PriceListId = id;
    }
  }
}

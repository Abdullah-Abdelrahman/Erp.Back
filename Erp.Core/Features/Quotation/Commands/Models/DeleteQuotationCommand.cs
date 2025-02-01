using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Commands.Models
{
  public class DeleteQuotationCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteQuotationCommand(int id)
    {
      Id = id;
    }

  }
}

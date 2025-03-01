using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceiptCategory.Commands.Models
{
  public class DeleteReceiptCategoryCommand : IRequest<Response<string>>
  {
    public int ReceiptCategoryId { get; set; }

    public DeleteReceiptCategoryCommand(int id)
    {
      ReceiptCategoryId = id;
    }
  }
}

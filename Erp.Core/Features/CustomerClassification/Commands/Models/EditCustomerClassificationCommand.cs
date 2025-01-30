using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerClassification.Commands.Models
{
  public class EditCustomerClassificationCommand : IRequest<Response<string>>
  {
    public int CustomerClassificationId { get; set; }
    public string CustomerClassificationName { get; set; } = null!;
  }
}

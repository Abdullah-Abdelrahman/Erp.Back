using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CustomerClassification.Commands.Models
{
  public class AddCustomerClassificationCommand : IRequest<Response<string>>
  {

    public string CustomerClassificationName { get; set; } = null!;


  }
}

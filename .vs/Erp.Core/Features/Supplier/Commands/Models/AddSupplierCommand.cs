using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Supplier.Commands.Models
{
  public class AddSupplierCommand : IRequest<Response<string>>
  {

    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }


  }
}

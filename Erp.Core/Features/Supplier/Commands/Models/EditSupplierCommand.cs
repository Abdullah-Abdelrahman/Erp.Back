using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Supplier.Commands.Models
{
  public class EditSupplierCommand : IRequest<Response<string>>
  {
    [Required]
    public int SupplierId { get; set; }

    [Required]
    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }
  }
}

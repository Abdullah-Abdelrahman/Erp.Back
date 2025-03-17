using Erp.Core.Features.Payment.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Payment.Queries.Models
{
  public class GetSupplierPaymentByIdQuery : IRequest<Response<GetSupplierPaymentByIdResult>>
  {
    public int Id { get; set; }

    public GetSupplierPaymentByIdQuery(int id)
    {
      Id = id;
    }
  }
}

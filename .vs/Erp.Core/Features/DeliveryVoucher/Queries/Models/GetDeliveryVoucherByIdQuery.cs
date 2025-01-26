using Erp.Data.Dto.DeliveryVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DeliveryVoucher.Queries.Models
{
  public class GetDeliveryVoucherByIdQuery : IRequest<Response<GetDeliveryVoucherByIdDto>>
  {
    public int Id { get; set; }

    public GetDeliveryVoucherByIdQuery(int id)
    {
      Id = id;
    }
  }
}

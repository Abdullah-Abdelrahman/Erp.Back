using Erp.Data.Dto.ReceivingVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceivingVoucher.Queries.Models
{
  public class GetReceivingVoucherByIdQuery : IRequest<Response<GetReceivingVoucherByIdDto>>
  {
    public int Id { get; set; }

    public GetReceivingVoucherByIdQuery(int id)
    {
      Id = id;
    }
  }
}

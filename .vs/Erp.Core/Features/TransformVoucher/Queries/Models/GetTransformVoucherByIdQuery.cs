using Erp.Data.Dto.TransformVoucher.cs;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.TransformVoucher.Queries.Models
{
  public class GetTransformVoucherByIdQuery : IRequest<Response<GetTransformVoucherByIdDto>>
  {
    public int Id { get; set; }

    public GetTransformVoucherByIdQuery(int id)
    {
      Id = id;
    }
  }
}

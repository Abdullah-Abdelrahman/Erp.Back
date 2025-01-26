using Erp.Data.Dto.TransformVoucher;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.TransformVoucher.Commands.Models
{
  public class EditTransformVoucherCommand : UpdateTransformVoucherRequest, IRequest<Response<string>>
  {


  }
}

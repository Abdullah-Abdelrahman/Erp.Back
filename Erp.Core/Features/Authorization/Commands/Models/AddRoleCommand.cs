using Erp.Data.Dto.ApplicationRole;
using MediatR;
using Name.Core.Bases;

namespace Name.Core.Features.Authorization.Commands.Models
{
  public class AddRoleCommand : AddApplicationRoleRequest, IRequest<Response<string>>
  {

  }
}

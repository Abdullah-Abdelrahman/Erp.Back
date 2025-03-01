using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Company.Commands.Models
{
  public class DeleteCompanyCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteCompanyCommand(int id)
    {
      Id = id;
    }
  }
}

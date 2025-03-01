using Erp.Core.Features.Company.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Company.Queries.Models
{
  public class GetCompanyByIdQuery : IRequest<Response<GetCompanyByIdResult>>
  {
    public int Id { get; set; }

    public GetCompanyByIdQuery(int id)
    {
      Id = id;
    }
  }
}

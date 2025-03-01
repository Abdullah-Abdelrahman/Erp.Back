using Erp.Core.Features.JobType.Queries.Results;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.JobType
{
  public partial class JobTypeProfile
  {

    public void GetJobTypeByIdMapping()
    {
      CreateMap<Entitis.JobType, GetJobTypeByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.ID)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));


    }
  }
}

using Erp.Core.Features.JobType.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.JobType
{
  public partial class JobTypeProfile
  {

    public void AddJobTypeMapping()
    {
      CreateMap<AddJobTypeCommand, Entitis.JobType>()
       .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));
    }
  }
}

using Erp.Core.Features.JobType.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.JobType
{
  public partial class JobTypeProfile
  {
    public void EditJobTypeMapping()
    {
      CreateMap<EditJobTypeCommand, Entitis.JobType>()
   .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));
    }
  }
}

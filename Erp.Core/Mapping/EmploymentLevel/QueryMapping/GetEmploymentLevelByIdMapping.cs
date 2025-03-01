using Erp.Core.Features.EmploymentLevel.Queries.Results;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.EmploymentLevel
{
  public partial class EmploymentLevelProfile
  {

    public void GetEmploymentLevelByIdMapping()
    {
      CreateMap<Entitis.EmploymentLevel, GetEmploymentLevelByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.ID)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));


    }
  }
}

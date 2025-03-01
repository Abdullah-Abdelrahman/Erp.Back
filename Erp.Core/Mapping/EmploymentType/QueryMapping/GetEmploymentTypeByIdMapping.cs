using Erp.Core.Features.EmploymentType.Queries.Results;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.EmploymentType
{
  public partial class EmploymentTypeProfile
  {

    public void GetEmploymentTypeByIdMapping()
    {
      CreateMap<Entitis.EmploymentType, GetEmploymentTypeByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.ID)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));


    }
  }
}

using AutoMapper;

namespace Erp.Core.Mapping.JobType
{
  public partial class JobTypeProfile : Profile
  {
    public JobTypeProfile()
    {
      AddJobTypeMapping();
      EditJobTypeMapping();

      GetJobTypeByIdMapping();
    }
  }
}

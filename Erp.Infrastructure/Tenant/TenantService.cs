using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Service.Abstracts.MainModule;

namespace Erp.Service.Implementations.MainModule
{
  public class TenantService : ITenantService
  {

    private readonly ITenantRepository _tenantRepository;
    public string? TenantId { get; set; }
    public TenantService(ITenantRepository tenantRepository)
    {
      _tenantRepository = tenantRepository;
    }

    public async Task<bool> SetTenant(string tenantId)
    {
      var tenant = await _tenantRepository.GetByIdAsync(tenantId);

      if (tenant != null)
      {
        TenantId = tenant.Id;
        return true;
      }

      throw new Exception(message: "invalid Tenant");
    }
  }
}

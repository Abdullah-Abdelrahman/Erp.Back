namespace Erp.Service.Abstracts.MainModule
{
  public interface ITenantService
  {
    public Task<bool> SetTenant(string tenantId);
    public string? TenantId { get; set; }

  }
}

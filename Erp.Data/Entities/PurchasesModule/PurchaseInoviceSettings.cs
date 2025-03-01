namespace Erp.Data.Entities.PurchasesModule
{
  public class PurchaseInoviceSettings : IMustHaveTenant
  {
    public int PurchaseInoviceSettingsId { get; set; }
    public string TenantId { get; set; } = null!;

  }
}

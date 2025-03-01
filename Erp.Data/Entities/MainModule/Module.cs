namespace Erp.Data.Entities.MainModule
{
  public class Module
  {
    public int ModuleID { get; set; }

    public string ModuleName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    public ICollection<ApplicationClaim> ClaimList { get; set; } = new List<ApplicationClaim>();
  }

}

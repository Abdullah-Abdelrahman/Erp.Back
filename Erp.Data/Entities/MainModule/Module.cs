namespace Erp.Data.Entities.MainModule
{
  public class Module
  {
    public int ModuleID { get; set; }

    public string ModuleName { get; set; } = string.Empty;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


    public List<string> ClaimList { get; set; } = new List<string>();
  }

}

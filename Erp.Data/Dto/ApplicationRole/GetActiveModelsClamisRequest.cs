namespace Erp.Data.Dto.ApplicationRole
{
  public class GetActiveModelsClamisRequest
  {

    public List<ActiveModelClamis> ActiveModelsClamis { get; set; } = new List<ActiveModelClamis>();
  }
  public class ActiveModelClamis
  {
    public string name { get; set; }

    public List<string> clamis { get; set; } = new List<string>();

  }
}

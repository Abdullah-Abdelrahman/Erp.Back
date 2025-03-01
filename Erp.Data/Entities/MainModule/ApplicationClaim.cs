using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.MainModule
{
  public class ApplicationClaim
  {

    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
  }
}

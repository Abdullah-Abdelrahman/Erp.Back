using Microsoft.AspNetCore.Identity;

namespace Erp.Data.Entities.MainModule
{
  public class UserBase : IdentityUser
  {

    public string Name { get; set; }

    public int CompanyId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    //[EncryptColumn]
    public string? Code { get; set; }

  }

}

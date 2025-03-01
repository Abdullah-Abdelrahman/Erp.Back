using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.MainModule
{
  public class UserBase : IdentityUser, IMustHaveTenant
  {

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    //[EncryptColumn]
    public string? Code { get; set; }


    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; }
    public string TenantId { get; set; } = null!;

  }

}

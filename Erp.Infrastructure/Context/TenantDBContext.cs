using Erp.Data.Entities.MainModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Infrastructure.Context
{
  public class TenantDBContext : DbContext
  {
    public TenantDBContext(DbContextOptions<TenantDBContext> options) : base(options)
    {

    }

    public DbSet<Tenant> tenants { get; set; }
  }
}

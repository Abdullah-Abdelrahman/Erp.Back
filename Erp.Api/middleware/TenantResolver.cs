using Erp.Service.Abstracts.MainModule;
using System.IdentityModel.Tokens.Jwt;

namespace Erp.Api.middleware
{
  public class TenantResolver
  {

    private readonly RequestDelegate _next;

    public TenantResolver(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
    {
      string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

      if (!string.IsNullOrEmpty(token))
      {
        //set tenant id in scoped service
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "tenantId")?.Value;

        if (id != null)
        {
          await tenantService.SetTenant(id);

        }
      }

      await _next(context);
    }
  }
}

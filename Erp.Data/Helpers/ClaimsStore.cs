using System.Security.Claims;

namespace Name.Data.Helpers
{
  public static class ClaimsStore
  {
    public static List<Claim> Accountsclaims = new()
        {
            new Claim("Add New Assets","false"),
            new Claim("View Cost Centers","false"),
            new Claim("Cost Center Management","false"),
        };




  }
}

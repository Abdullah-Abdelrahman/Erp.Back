namespace Erp.Data.Dto.ApplicationRole
{
  public class GetApplicationRoleRequest
  {
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<ModelClaimsDto> modelClaimsDtos { get; set; } = new List<ModelClaimsDto>();
  }

  public class ModelClaimsDto
  {
    public int ModelId { get; set; }
    public string ModelName { get; set; } = null!;
    public List<ClaimDto> claims { get; set; } = new List<ClaimDto>();
  }
  public class ClaimDto
  {
    public string name { get; set; }

    public bool value { get; set; }
  }

}

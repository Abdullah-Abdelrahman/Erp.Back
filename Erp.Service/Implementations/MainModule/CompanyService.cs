using Erp.Data.Entities.MainModule;
using Erp.Data.MetaData;
using Erp.Infrastructure;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Service.Abstracts.MainModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;
using System.Security.Claims;

namespace Erp.Service.Implementations.MainModule
{
  public class CompanyService : ICompanyService
  {


    private readonly ICompanyRepository _CompanyRepository;

    private readonly IUserBaseService _userBaseService;

    private readonly ITenantRepository _tenantRepository;

    private readonly DataSeeder _dataSeeder;


    private readonly UserManager<UserBase> _userManager;
    public CompanyService(ICompanyRepository CompanyRepository,
      IUserBaseService userBaseService,
      UserManager<UserBase> userManager,
      ITenantRepository tenantRepository,
  DataSeeder dataSeeder)
    {
      _CompanyRepository = CompanyRepository;
      _userBaseService = userBaseService;
      _userManager = userManager;
      _tenantRepository = tenantRepository;
      _dataSeeder = dataSeeder;
    }

    public async Task<string> AddCompanyAsync(Company Company)
    {

      //may cause performance issues
      var g = Guid.NewGuid();
      Company.TenantId = "Company_" + g.ToString();
      var newTenant = await _tenantRepository.AddAsync(new Tenant
      {
        Id = Company.TenantId,
        Name = Company.TenantId
      });

      var newCompany = await _CompanyRepository.AddAsync(Company);
      UserBase user = new UserBase()
      {
        Name = Company.CompanyEmail,
        UserName = Company.CompanyEmail,
        Email = Company.CompanyEmail,
        CompanyId = Company.CompanyID,
        TenantId = Company.TenantId
      };

      try
      {





        var result = await _userBaseService.AddUserAsync(user, Company.Password);

        if (result != "Success")
        {
          await DeleteAsync(newCompany);
          await _tenantRepository.DeleteAsync(newTenant);
          return "There is a problem in creating Account : " + result;
        }
        var value = newCompany.TenantId;
        var claim = new Claim("tenantId", value);
        var addUserClaimResult = await _userManager.AddClaimAsync(user, claim);




        _dataSeeder.Seed(newCompany.TenantId).GetAwaiter().GetResult();

        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        await DeleteAsync(newCompany);
        await _tenantRepository.DeleteAsync(newTenant);
        return "There is a problem in adding the Company please try again : " + ex.Message;
      }
    }

    public async Task<string> DeleteAsync(Company Company)
    {
      try
      {
        await _CompanyRepository.DeleteAsync(Company);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Company : " + ex.Message;
      }

    }

    public async Task<Company> GetCompanyByIdAsync(int id)
    {
      var Company = await _CompanyRepository.GetTableNoTracking().Where(x => x.CompanyID == id).SingleOrDefaultAsync();

      return Company;
    }

    public async Task<List<Company>> GetCompanysListAsync()
    {
      var Companys = await _CompanyRepository.GetCompanysListAsync();

      return Companys;
    }

    public async Task<string> UpdateAsync(Company Company)
    {
      var transact = _CompanyRepository.BeginTransaction();
      try
      {
        await _CompanyRepository.UpdateAsync(Company);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}

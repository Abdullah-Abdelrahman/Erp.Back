using Erp.Data.Entities.HumanResources.Staff;

namespace Erp.Core.Features.Employee.Queries.Results
{
  public class GetEmployeeByIdResult
  {


    public int EmployeeID { get; set; }




    public string FirstName { get; set; } = null!;



    public string LastName { get; set; } = null!;

    public string Notes { get; set; } = string.Empty;
    public string? ImagePath { get; set; }


    public byte[]? ImageFile { get; set; }


    public string Email { get; set; } = string.Empty;


    public EmploymentStatus Status { get; set; } = EmploymentStatus.Active;


    public string RoleID { get; set; } = null!;

    //-- Personal information --

    public DateTime DateOfBirth { get; set; }

    public Gender? Gender { get; set; }

    public string Country { get; set; } = string.Empty;

    // -- Contact information --

    public string? PhoneNumber { get; set; }

    public string? Landline { get; set; }

    public string? PrivateEmail { get; set; }

    // -- Location --

    public string? Address1 { get; set; } = string.Empty;
    public string? Address2 { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    //المنطقه
    public string? zone { get; set; } = string.Empty;
    public string? postcode { get; set; } = string.Empty;


    // -- Job Information --

    //المسمي الوظيفيDesignation
    public int? JobTypeID { get; set; }


    public int? DepartmentID { get; set; }


    public DateTime HireDate { get; set; } = DateTime.Now;

    public int? EmploymentLevelId { get; set; }

    public int? EmploymentTypeId { get; set; }

    public int? DirectManagerId { get; set; }


    public bool UseDefaultFinancialHistory { get; set; } = true;

  }
}

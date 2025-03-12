using Erp.Data.Entities.HumanResources.Staff;
using MediatR;
using Microsoft.AspNetCore.Http;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Employee.Commands.Models
{
  public class EditEmployeeCommand : IRequest<Response<string>>
  {
    [Required]
    public int EmployeeID { get; set; }



    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;


    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    public string? Notes { get; set; } = string.Empty;

    public IFormFile? ImageFile { get; set; }


    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public EmploymentStatus Status { get; set; } = EmploymentStatus.Active;

    [Required]
    public string RoleID { get; set; } = null!;

    //-- Personal information --
    [Required]
    public DateTime DateOfBirth { get; set; }

    public Gender? Gender { get; set; }
    [Required]
    public string Country { get; set; } = string.Empty;

    // -- Contact information --
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    public string? Landline { get; set; }
    [EmailAddress]
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

    [Required]
    public DateTime HireDate { get; set; } = DateTime.Now;

    public int? EmploymentLevelId { get; set; }

    public int? EmploymentTypeId { get; set; }

    public int? DirectManagerId { get; set; }

    [Required]
    public bool UseDefaultFinancialHistory { get; set; } = true;

  }
}

using System.ComponentModel.DataAnnotations;
using static EmployeeRepositoryAPI.Models.Enums;

namespace EmployeeRepositoryAPI.Models;

public class Employee
{
    public int Id { get; set; }
    [Required]
    [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;
    public Position Position { get; set; }
    public int Salary { get; set; }
    public DateTime? HireDate { get; set; } 
    

}

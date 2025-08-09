using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Extension { get; set; }
        public string? Email { get; set; }
        public string Extension { get; set; }
        public string? JobTitle { get; set; }
        public string? OfficeCode { get; set; }
        public int? ReportsTo { get; set; }
    }
}

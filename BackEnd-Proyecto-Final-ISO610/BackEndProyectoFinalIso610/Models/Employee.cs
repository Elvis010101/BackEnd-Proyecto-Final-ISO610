namespace Backend.Models
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? JobTitle { get; set; }
        public string? OfficeCode { get; set; }
        public int? ReportsTo { get; set; }
    }
}

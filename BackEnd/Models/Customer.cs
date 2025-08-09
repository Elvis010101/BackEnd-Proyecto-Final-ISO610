namespace Backend.Models
{
    public class Customer
    {
        public int CustomerNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public decimal? CreditLimit { get; set; }
        public int? SalesRepEmployeeNumber { get; set; }
    }
}

namespace Backend.Models
{
    public class Payment
    {
        public int CustomerNumber { get; set; }
        public string? CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}

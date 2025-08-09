using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Payment
    {
        [Key]
        public int CustomerNumber { get; set; }
        [Key]
        public string? CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}

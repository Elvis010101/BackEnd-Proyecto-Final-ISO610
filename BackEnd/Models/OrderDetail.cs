using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderNumber { get; set; }
        [Key]
        public string? ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public int OrderLineNumber { get; set; }
    }
}

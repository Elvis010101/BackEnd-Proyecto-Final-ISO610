using System.ComponentModel.DataAnnotations;

namespace BackEndProyectoFinalIso610.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? Status { get; set; }
        public string? Comments { get; set; }
        public int CustumerNumber { get; set; }
    }
}

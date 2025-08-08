namespace BackEndProyectoFinalIso610.Models
{
    public class Product
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductLine { get; set; }
        public int QuantityInStock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal MSRP { get; set; }
    }
}

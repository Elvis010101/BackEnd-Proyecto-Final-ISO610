using Newtonsoft.Json;

namespace Backend.Models
{
    public class ProductLine
    {
        public string? ProductLineName { get; set; }
        public string? textDescription { get; set; }
        public string? htmlDescription { get; set; }
        public byte[]? image { get; set; }
    }
}

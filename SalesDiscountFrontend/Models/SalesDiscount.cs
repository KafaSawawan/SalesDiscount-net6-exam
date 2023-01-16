namespace SaveMoneyApp.Models
{
    public class SalesDiscount
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Avavible { get; set; }
    }
}

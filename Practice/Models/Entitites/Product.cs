namespace Practice.Models.Entities
{
    public enum Currency
    {
        USD,
        NRS
    }

    public class Product
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Class { get; set; } = "";
        public int Quantity { get; set; }
        public string Price { get; set; } = "";
        public Currency Currency { get; set; }
    }
}

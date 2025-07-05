namespace Project_Sujal.Models.Entities
{
	public class Product
	{
		public Guid ID { get; set; } = Guid.NewGuid();
		public required string Name { get; set; }

		public required string Category { get; set; }

		public required string Class { get; set; }
		public required int Quantity { get; set; }
		public required string Price { get; set; }
	}
}

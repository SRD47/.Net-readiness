using ProductApp.Database;

namespace ProductApp.DTO
{
    public class ProductUpdateDto
    {
            public string? ProName { get; set; }
            public string? Category { get; set; }
            public string? Class { get; set; }
            public int? Quantity { get; set; }
            public Currency? Currency { get; set; }
            public decimal? Price { get; set; }
    }

}

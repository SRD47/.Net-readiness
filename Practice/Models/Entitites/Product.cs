using System;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models.Entities
{
    public enum Currency
    {
        USD,
        NRS
    }

    public class Product
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 20 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Class is required.")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public Currency Currency { get; set; }
    }
}

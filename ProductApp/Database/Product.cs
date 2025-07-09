using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductApp.Database
{
    public enum Currency
    {
        [Description("Nepalese Dollar")]
        NRS = 1,
        [Description("American Dollar")]
        USD = 2
    }
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required]
        [StringLength(20,MinimumLength =5)]
        public string ProName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        //[Range(1,100)]
        public int Quantity { get; set; }
        [Required]
        public Currency Currency { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

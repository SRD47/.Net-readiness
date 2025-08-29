using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDesktop.Entities
{

    public enum Currency
    {
        NRS = 1,
        INR,
        USD
    }
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category {  get; set; }
        public int Quantity { get; set; }
        public int InStock { get; set; }
        public Currency Currency { get; set; }
        public double Price { get; set; }
        //public string ImgSrc {  get; set; }
    }
}

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

    public enum Category
    {
        FoodAndBeverages = 1,
        ElectronicsAndAppliances, 
        ClothingAndFashion,
        HealthAndBeauty,
        HomeAndLiving,
        ToysAndGames 
    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category {  get; set; }
        public int Stock { get; set; }
        public Currency Currency { get; set; }
        public double Price { get; set; }
        [NotMapped]
        private bool _Editable;
        [NotMapped]
        public bool Editable { get =>  _Editable;
                           set => _Editable = value;}
        
    }
}

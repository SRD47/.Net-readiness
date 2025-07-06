using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Database
{
    public enum Currency
    {
        NRS = 1,
        USD = 2
    }
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required]
        public string ProName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Currency Currency { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

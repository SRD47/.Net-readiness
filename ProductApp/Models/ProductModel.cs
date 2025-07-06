using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProName { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public int Quantity { get; set; }
        public string Currency { get; set; }
        public double Price{ get; set; }
        

    }
}

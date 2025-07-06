using ProductApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DTO
{
    public class ProductUpdateDto
    {
            public string? ProName { get; set; }
            public string? Category { get; set; }
            public string? Class { get; set; }
            public int? Quantity { get; set; }
            public Currency? Currency { get; set; }
            public double? Price { get; set; }
    }

}

using ProductApp.Models;
using ProductApp.DTO;
using ProductApp.Extension;

namespace ProductApp.Service
{
    public static class DisplayProduct
    {
        public static void DisplayProductAll(this List<Product> collection)
        {
            foreach (var item in collection)
            {
                $"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}".InfoColor();
            }
        }
    }
}

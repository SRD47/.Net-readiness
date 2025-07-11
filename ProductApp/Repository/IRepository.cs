using ProductApp.Models;
using System.Globalization;


namespace ProductApp.Repository
{
    public interface IRepository
    {
        Product GetProductsById(int id);
        List<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> FilterProductByName(string name);
    }
}

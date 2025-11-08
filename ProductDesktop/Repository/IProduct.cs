using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public interface IProduct
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

    }
}

using ProductApp.Database;
using ProductApp.Models;
using ProductApp.DTO;
using ProductApp.Repository;

namespace ProductApp.Service
{
    public class ProductDbService
    {
        private readonly ProductRepository _productrepo;

        public ProductDbService(ProductRepository productrepo)
        {
            _productrepo = productrepo;
        }

        public void AddProduct(Product product)
        {
            _productrepo.AddProduct(product);
        }
        public List<Product> ViewProducts()
        {
          return _productrepo.GetProducts();
        }
        public void DeleteProduct(int id) {

            var deleteproduct = _productrepo.GetProductsById(id);
            
            if (deleteproduct != null)
            {
                _productrepo.DeleteProduct(deleteproduct);
            }
        }
        public bool UpdateProduct(int id, ProductUpdateDto newProduct)
        {
            var oldProduct = _productrepo.GetProductsById(id);

            if (oldProduct == null) {
                return false;
            }

            if(!string.IsNullOrEmpty(newProduct.ProName)) 
                oldProduct.ProName = newProduct.ProName;

            if (!string.IsNullOrEmpty(newProduct.Category))
                oldProduct.Category = newProduct.Category;

            if (!string.IsNullOrEmpty(newProduct.Class))
                oldProduct.Class = newProduct.Class;

            if (newProduct.Quantity.HasValue)
                oldProduct.Quantity = newProduct.Quantity.Value;
            
            if (newProduct.Price.HasValue)
                oldProduct.Price = newProduct.Price.Value;

            if(newProduct.Currency.HasValue)
                oldProduct.Currency = newProduct.Currency.Value;

            _productrepo.UpdateProduct(oldProduct);
            
            return true;

        }

        public List<Product> FilterDataByName(string name)
        {
           return _productrepo.FilterProductByName(name);
        }
    }
}

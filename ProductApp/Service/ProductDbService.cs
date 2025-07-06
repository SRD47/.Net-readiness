using ProductApp.Database;
using ProductApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Service
{
    public class ProductDbService
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDbService(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void AddProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
        }
        public  List<Product> ViewProducts()
        {
            return _productDbContext.Products.ToList();
        }
        public void DeleteProduct(int id) {

            var deleteproduct =  _productDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (deleteproduct != null)
            {
                _productDbContext.Products.Remove(deleteproduct);
                _productDbContext.SaveChanges();
            }
        }
        public bool UpdateProduct(int id, ProductUpdateDto newProduct)
        {
            var oldProduct = _productDbContext.Products.FirstOrDefault(p => p.Id == id);

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


            _productDbContext.SaveChanges();
            return true;

        }

        public List<Product> FilterDataByName(string name)
        {
           return _productDbContext.Products.Where(p => p.ProName.ToLower().Contains(name.ToLower())).ToList() ;
        }
    }
}

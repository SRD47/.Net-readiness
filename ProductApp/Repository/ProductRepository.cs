using ProductApp.Database;
using ProductApp.Models;

namespace ProductApp.Repository
{
    public class ProductRepository:IRepository
    {
        private readonly ProductDbContext _dbcontext;

        public ProductRepository(ProductDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Product GetProductsById(int id)
        {
            return _dbcontext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts() 
        {
            return _dbcontext.Products.ToList(); 
        }

        public void AddProduct(Product product) { 
        
            _dbcontext.Products.Add(product);   
            _dbcontext.SaveChanges();
        }

        public void UpdateProduct(Product product) { 
            _dbcontext.Products.Update(product);
            _dbcontext.SaveChanges();
        }

        public void DeleteProduct(Product product) 
        { 
            _dbcontext.Products.Remove(product); 
            _dbcontext.SaveChanges();
        }

        public List<Product> FilterProductByName(string name)
        {
           return _dbcontext.Products.Where(p => p.ProName.ToLower().Contains(name.ToLower())).ToList();
        } 
    }
}

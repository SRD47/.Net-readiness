using ProductDesktop.Database;
using ProductDesktop.Entities;
using Serilog;

namespace ProductDesktop.Repository
{
    public class ProductRepository:IProduct
    {
        public readonly DatabaseContext _dbcontext;
        public ProductRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async void AddProduct(Product product)
        {
            await _dbcontext.AddAsync(product);
            await _dbcontext.SaveChangesAsync();
            Log.Information("Product added successfully.");
        }
        public async void UpdateProduct(Product product)
        {
            _dbcontext.Update(product);
            await _dbcontext.SaveChangesAsync();
            Log.Information($"Product{product.Name} added successfully.");
        }
        public async void DeleteProduct(Product product)
        {
            _dbcontext.Products.Remove(product);
            await _dbcontext.SaveChangesAsync();
            Log.Information($"Product{product.Name} removed.");
        }
    }
}

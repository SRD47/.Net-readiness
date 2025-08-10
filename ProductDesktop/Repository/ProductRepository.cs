using ProductDesktop.Database;
using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public class ProductRepository:IProduct
    {
        public readonly DatabaseContext _dbcontext;
        public ProductRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void AddProduct(Product product)
        {
            _dbcontext.Add(product);
            _dbcontext.SaveChanges();
        }
    }
}

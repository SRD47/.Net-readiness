using ProductDesktop.Database;
using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public class SupplierRepo : ISupplier
    {
        public readonly DatabaseContext _dbcontext;
        public SupplierRepo(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void AddSupplier(Supplier supplier)
        {
            _dbcontext.Add(supplier);
            _dbcontext.SaveChanges();
        }
    }
}

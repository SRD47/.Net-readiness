using ProductDesktop.Database;
using ProductDesktop.Entities;
using Serilog;

namespace ProductDesktop.Repository
{
    public class SupplierRepo : ISupplier
    {
        public readonly DatabaseContext _dbcontext;
        public SupplierRepo(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async void AddSupplier(Supplier supplier)
        {
            await _dbcontext.AddAsync(supplier);
            await _dbcontext.SaveChangesAsync();
            Log.Information($"Supplier {supplier.SupplierName} added.");

        }
        public async void UpdateSupplier(Supplier supplier)
        {
            _dbcontext.Update(supplier);
            await _dbcontext.SaveChangesAsync();
            Log.Information($"Supplier:{supplier.SupplierName} details changed.");

        }

        public async void DeleteSupplier(Supplier supplier)
        {
            _dbcontext.Suppliers.Remove(supplier);
            await _dbcontext.SaveChangesAsync();
            Log.Information($"Product{supplier.SupplierName} removed.");
        }
    }
}

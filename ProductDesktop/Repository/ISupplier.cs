using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public interface ISupplier
    {
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
    }
}

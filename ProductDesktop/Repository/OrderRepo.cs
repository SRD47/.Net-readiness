using ProductDesktop.Database;
using ProductDesktop.Entities;
using Serilog;

namespace ProductDesktop.Repository
{
    public class OrderRepo : IOrder
    {
        public readonly DatabaseContext _dbcontext;
        public OrderRepo(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async void AddOrder(Order order)
        {
            await _dbcontext.AddAsync(order);
            await _dbcontext.SaveChangesAsync();
            Log.Information($"New Order for Product{order.ProductName} placed.");

        }
    }
}

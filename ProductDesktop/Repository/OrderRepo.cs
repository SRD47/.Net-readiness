using ProductDesktop.Database;
using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public class OrderRepo : IOrder
    {
        public readonly DatabaseContext _dbcontext;
        public OrderRepo(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void AddOrder(Order order)
        {
            _dbcontext.AddAsync(order);
            _dbcontext.SaveChangesAsync();
        }
    }
}

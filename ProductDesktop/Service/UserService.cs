using ProductDesktop.Database;

namespace ProductDesktop.Service
{
    public class UserService
    {
        private readonly DatabaseContext _dbContext;
        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext; 
        }

        
    }
}

using ProductDesktop.Database;
using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public class UserRepository:IUser
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }
        public void AddUser(AppUsers User) {

            _databaseContext.Add(User);
            _databaseContext.SaveChanges();
        }
    }
}

using ProductDesktop.Database;

namespace ProductDesktop.Repository
{
    public class UserRepository:IUser
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }
        public void AddUser(Users User) {

            _databaseContext.Add(User);
            _databaseContext.SaveChanges();
        }
    }
}

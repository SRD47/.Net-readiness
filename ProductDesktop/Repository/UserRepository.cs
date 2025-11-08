using ProductDesktop.Database;
using ProductDesktop.Entities;
using Serilog;

namespace ProductDesktop.Repository
{
    public class UserRepository:IUser
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }
        public async void AddUserAsync(AppUsers User) {

            await _databaseContext.AddAsync(User);
            await _databaseContext.SaveChangesAsync();
            Log.Information($"New User {User.Name} added.");

        }


    }
}

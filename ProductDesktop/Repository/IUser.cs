using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public interface IUser
    {
        Task AddUserAsync(AppUsers User);
    }
}

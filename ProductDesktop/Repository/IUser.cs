using ProductDesktop.Entities;

namespace ProductDesktop.Repository
{
    public interface IUser
    {
        void AddUserAsync(AppUsers User);
    }
}

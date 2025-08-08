using CommunityToolkit.Mvvm.ComponentModel;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using System.Collections.ObjectModel;

namespace ProductDesktop.ViewModel
{
    public partial class StaffViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AppUsers> userlist;


        private readonly DatabaseContext _dbcontext;
        public StaffViewModel(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;

            GetUsersData();
        }

        private void GetUsersData() {

            var appUsers = _dbcontext.AppUsers.ToList();

            Userlist = new ObservableCollection<AppUsers>(appUsers);
        }
        
    }
}

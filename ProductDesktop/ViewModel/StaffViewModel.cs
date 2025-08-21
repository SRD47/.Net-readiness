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

        [ObservableProperty]
        private ObservableCollection<Product> productlist;

        [ObservableProperty]
        private ObservableCollection<Product> selectedProduct = new();

        [ObservableProperty]
        private double totalAmount;


        private readonly DatabaseContext _dbcontext;

        public StaffViewModel(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;

            GetUsersData();
            GetProductData();
        }

        private void GetUsersData() {

            var appUsers = _dbcontext.AppUsers.ToList();

            Userlist = new ObservableCollection<AppUsers>(appUsers);
        }

        private void GetProductData()
        {

            var products = _dbcontext.Products.ToList();

            Productlist = new ObservableCollection<Product>(products);
        }
    }
}

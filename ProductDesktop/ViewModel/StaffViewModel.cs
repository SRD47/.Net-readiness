using CommunityToolkit.Mvvm.ComponentModel;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using System.Collections.ObjectModel;

namespace ProductDesktop.ViewModel
{
    public partial class StaffViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AppUsers> userList;

        [ObservableProperty]
        private ObservableCollection<Product> productList;

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

            var appUsers = _dbcontext.AppUsers.ToList();  //ToRepo

            UserList = new ObservableCollection<AppUsers>(appUsers);
            OnPropertyChanged(nameof(UserList));
        }

        private void GetProductData()
        {

            var products = _dbcontext.Products.ToList();

            ProductList = new ObservableCollection<Product>(products);
            OnPropertyChanged(nameof(ProductList));
        }
    }
}

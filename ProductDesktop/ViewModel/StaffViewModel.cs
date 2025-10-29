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

        //Product
        [ObservableProperty]
        private ObservableCollection<Product> productList;

        [ObservableProperty]
        private ObservableCollection<Product> selectedProduct = new();



        //Supplier
        [ObservableProperty]
        private ObservableCollection<Supplier> supplierList;

        private List<Supplier> AllSuppliers;

        [ObservableProperty]
        private ObservableCollection<Supplier> selectedSupplier = new();

        //Order
        [ObservableProperty]
        private ObservableCollection<Order> ordersList;

        private List<Order> AllOrders;

        [ObservableProperty]
        private double totalAmount;




        private readonly DatabaseContext _dbcontext;

        public StaffViewModel(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;

            GetUsersData();
            GetProductData();
            GetSuppliersData();
            GetOrdersData();

        }
        //AppUsers
        private void GetUsersData() {

            var appUsers = _dbcontext.AppUsers.ToList();  //ToRepo

            UserList = new ObservableCollection<AppUsers>(appUsers);
            OnPropertyChanged(nameof(UserList));
        }
        //Product
        private void GetProductData()
        {

            var products = _dbcontext.Products.ToList();

            ProductList = new ObservableCollection<Product>(products);
            OnPropertyChanged(nameof(ProductList));
        }

        //Order
        private void GetOrdersData()
        {
            AllOrders = _dbcontext.Orders.ToList();

            OrdersList = new ObservableCollection<Order>(AllOrders);
            OnPropertyChanged(nameof(OrdersList));
        }

        public void FilterOrders(string text)
        {

            if (string.IsNullOrEmpty(text))
            {
                OrdersList = new ObservableCollection<Order>(AllOrders);
            }
            else
            {
                var filteredOrders = AllOrders.Where(e => e.ProductName.Contains(text,StringComparison.OrdinalIgnoreCase) || e.Notes.Contains(text, StringComparison.OrdinalIgnoreCase) || e.Supplier.SupplierName.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();

                OrdersList = new ObservableCollection<Order>(filteredOrders);
            }

        }

        //Suppliers 
        private void GetSuppliersData()
        {
            AllSuppliers = _dbcontext.Suppliers.ToList();

            SupplierList = new ObservableCollection<Supplier>(AllSuppliers);
            OnPropertyChanged(nameof(SupplierList));
        }
        public void FilterSuppliers(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SupplierList = new ObservableCollection<Supplier>(AllSuppliers);
            }

            else
            {
                var filtered = AllSuppliers.Where(s => s.SupplierName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                       (s.ContactPerson?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) ||
                       (s.Email?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false)).ToList();

                SupplierList = new ObservableCollection<Supplier>(filtered);
            }
        }
    }
}

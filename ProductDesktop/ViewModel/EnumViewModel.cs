using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace ProductDesktop.ViewModel
{
    public partial class EnumViewModel : ObservableObject
    {

        //User, Role

        [ObservableProperty]
        private ObservableCollection<Roles> rolesbind;

        [ObservableProperty]
        private Roles selectedRole;

        [ObservableProperty]
        private AppUsers selecteduser;

        //Currency

        [ObservableProperty]
        private ObservableCollection<Currency> currencies;

        [ObservableProperty]
        private Currency selectedcurrency;


        //Category
        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private Category selectedcategory;
        
        [ObservableProperty]
        private ObservableCollection<Product> filterCategory;


        //Order Status

        [ObservableProperty]
        private ObservableCollection<OrderStatus> orderStatus;

        [ObservableProperty]
        private OrderStatus selectedStatus;

        //DbContext
        private readonly DatabaseContext _context;

        public EnumViewModel(DatabaseContext context)
        {

            _context = context;

            GetRoles();
            GetCurrencies();
            GetCategories();
            GetOrderStatus();

            RolesCommand = new RelayCommand<AppUsers>(UpdateRoles);
        }


        partial void OnSelectedcategoryChanged(Category value)  //test in other pages 
        {
            FilterCategoriesProduct();
        }


        public void GetRoles()
        {
            var rolesList = Enum.GetValues(typeof(Roles)).Cast<Roles>().ToList();
            Rolesbind = new ObservableCollection<Roles>(rolesList);
        }
        public void GetCurrencies()
        {
            var currenciesList = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();

            Currencies = new ObservableCollection<Currency>(currenciesList);
        }

        public void GetCategories()
        {
            var categoryList = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();

            Categories = new ObservableCollection<Category>(categoryList);
        }


        private void GetOrderStatus()
        {
            var orderStatusList = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();

            OrderStatus = new ObservableCollection<OrderStatus>(orderStatusList);
        }

        public void FilterCategoriesProduct()
        {

            var filteredProWthCategories = _context.Products.Where(e => e.Category == Selectedcategory).ToList();
            FilterCategory = new ObservableCollection<Product>(filteredProWthCategories);

        }




        public ICommand RolesCommand { get; }
        private async void UpdateRoles(AppUsers  user)
        {

            if (user != null )
            {

                user.Roles = user.NewRole;
                await  _context.SaveChangesAsync();

                OnPropertyChanged(nameof(user.Roles));
            }
            else
                return;
            
        }
    }
}
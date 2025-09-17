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
        [ObservableProperty]
        private ObservableCollection<Roles> rolesbind;

        [ObservableProperty]
        private Roles selectedRole;

        [ObservableProperty]
        private AppUsers selecteduser;

        [ObservableProperty]
        private ObservableCollection<Currency> currencies;

        [ObservableProperty]
        private Currency selectedcurrency;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private Category selectedcategory;

        private readonly DatabaseContext _context;

        public EnumViewModel(DatabaseContext context)
        {

            _context = context;

            GetRoles();
            GetCurrencies();
            GetCategories();

            RolesCommand = new RelayCommand<AppUsers>(UpdateRoles);
        }
        public void GetRoles()
        {
            var rolesList = Enum.GetValues(typeof(Roles)).Cast<Roles>().ToList();
            rolesbind = new ObservableCollection<Roles>(rolesList);
        }
        public void GetCurrencies()
        {
            var currenciesList = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();

            currencies = new ObservableCollection<Currency>(currenciesList);
        }

        public void GetCategories()
        {
            var categoryList = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();

            categories = new ObservableCollection<Category>(categoryList);
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
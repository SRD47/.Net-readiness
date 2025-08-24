using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductDesktop.ViewModel
{
    public partial class EnumViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Roles> rolesbind;

        [ObservableProperty]
        private Roles selectedrole;

        [ObservableProperty]
        private AppUsers selecteduser;

        [ObservableProperty]
        private ObservableCollection<Currency> currencies;

        private readonly DatabaseContext _context;

        public EnumViewModel(DatabaseContext context)
        {

            _context = context;

            GetRoles();
            GetCurrencies();
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
    }
}
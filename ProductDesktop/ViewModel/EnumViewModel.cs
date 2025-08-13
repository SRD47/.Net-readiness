using CommunityToolkit.Mvvm.ComponentModel;
using ProductDesktop.Entities;
using System.Collections.ObjectModel;

namespace ProductDesktop.ViewModel
{
    public partial class EnumViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Roles> rolesbind;

        [ObservableProperty]
        private ObservableCollection<Currency> currencies;

        public EnumViewModel()
        {
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

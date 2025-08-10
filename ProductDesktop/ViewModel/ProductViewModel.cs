using CommunityToolkit.Mvvm.ComponentModel;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using System.Collections.ObjectModel;

namespace ProductDesktop.ViewModel
{
    public partial class ProductViewModel : ObservableObject
    {

       [ObservableProperty]
       private ObservableCollection<Currency> currencies;
        public ProductViewModel()
        { 
            GetCurrencies();
        }
        public void GetCurrencies()
       {
            var currenciesList = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();

            Currencies = new ObservableCollection<Currency>(currenciesList); 
       }
    }
}

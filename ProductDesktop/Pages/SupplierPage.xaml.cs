using ProductDesktop.ViewModel;
using CommunityToolkit.Maui.Extensions;
using ProductDesktop.Entities;
using ProductDesktop.Database;


namespace ProductDesktop.Pages
{

    public partial class SupplierPage
    {

        private readonly DatabaseContext _context;

        public SupplierPage() : this(App.Services.GetRequiredService<DatabaseContext>()){} // Program needed Parameterless constructor 

        public SupplierPage(DatabaseContext context)
        {
            InitializeComponent();

            _context = context;

            var mainModel = App.Services.GetRequiredService<StaffViewModel>();
            BindingContext = mainModel;
        }

        private async void Add_Supplier(object sender, EventArgs e)
        {
            var addSupplier = App.Services.GetRequiredService<AddSupplierPopup>();
            await Application.Current.MainPage.ShowPopupAsync(addSupplier);
        }

        private async void Order_Btn(object sender, EventArgs e)
        {

            var button = sender as Button;
            var supplier = button.BindingContext as Supplier;

            if (supplier != null)
            {

                var OrderPopup = App.Services.GetRequiredService<OrderPagePopup>();
                OrderPopup.GetSupplierDetails(supplier);
                await Application.Current.MainPage.ShowPopupAsync(OrderPopup);
            }
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool decision = await App.Current.MainPage.DisplayAlert("Caution", "Delete this Supplier data?", "Yes", "No");

                if (decision)
                {

                    var button = sender as Button;
                    var supplier = button.BindingContext as Supplier;

                    if (supplier != null)
                    {

                        var SuppById = _context.Suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
                        _context.Suppliers.Remove(SuppById);
                        await _context.SaveChangesAsync();

                        var UI = BindingContext as StaffViewModel;
                        UI.SupplierList.Remove(supplier);
                    }
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                {
                    App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
            }
        }

        private void SearchBarChanged(object sender, TextChangedEventArgs e)
        {
            var model = App.Services.GetRequiredService<StaffViewModel>();
            model.FilterSuppliers(e.NewTextValue);
        }
    }
}
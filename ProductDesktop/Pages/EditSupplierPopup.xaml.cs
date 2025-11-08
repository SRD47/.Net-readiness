using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.ViewModel;
using Serilog;

namespace ProductDesktop.Pages;

public partial class EditSupplierPopup
{
    private readonly SupplierRepo _repo;
    public EditSupplierPopup(SupplierRepo repo)
    {
        InitializeComponent();

        _repo = repo;

        BindingContext = App.Services.GetRequiredService<EnumViewModel>();
        
    }


    public void GetSuppDetails(Supplier supplier)
    {
        BindingContext = supplier;

        CategoriesPicker.ItemsSource = App.Services.GetRequiredService<EnumViewModel>().Categories;
        CategoriesPicker.SelectedItem = supplier.Category;
    }

    private void Cancel_Btn(object sender, EventArgs e)
    {
        SupplierName_Entry.Text = string.Empty;
        ContactPerson_Entry.Text = string.Empty;
        PhoneNumber_Entry.Text = string.Empty;
        Email_Entry.Text = string.Empty;
        Description_Entry.Text = string.Empty;
    }

    private async void Save_Btn(object sender, EventArgs e)
    {

        try
        {

            var supplier = BindingContext as Supplier;
            if (supplier == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No supplier selected.", "OK");
                return;
            }

            _repo.UpdateSupplier(supplier);

            await App.Current.MainPage.DisplayAlert("Success", "Supplier updated successfully.", "OK");
            await CloseAsync();

        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
        }
    }



    private void CloseBtn_Clicked(object sender, EventArgs e)
    {
        CloseAsync();
    }
}
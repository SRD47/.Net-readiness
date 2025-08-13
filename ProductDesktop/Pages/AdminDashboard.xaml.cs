using CommunityToolkit.Maui.Extensions;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using ProductDesktop.ViewModel;


namespace ProductDesktop.Pages;

public partial class AdminDashboard : ContentPage
{
    private readonly DatabaseContext _databaseContext;

    private readonly UserRepository _userrepo;
    private readonly ProductRepository _productrepo;
    public AdminDashboard(DatabaseContext databaseContext, UserRepository repo,ProductRepository productrepo)
    {
        InitializeComponent();

        _databaseContext = databaseContext;
        _userrepo = repo;
        _productrepo = productrepo;


        var enumViewModel = App.Services.GetRequiredService<EnumViewModel>();
        BindingContext = enumViewModel;

    }
    private async void Staff_Button(object sender, EventArgs e)
    {
        try
        {
            var staffName = staff_name.Text.ValidateEmptyFields();
            var staffUsername = staff_username.Text.ValidateEmptyFields();
            var password = pass.Text.ValidateEmptyFields();
            var confirmed_pass = confirm_pass.Text.ValidateEmptyFields();


            string password_validated = ValidationExtension.ValidatePassword(password, confirmed_pass);

            var new_user = new AppUsers
            {
                Name = staffName,
                Username = staffUsername,
                Password = confirmed_pass,
            };
        }

        catch (Exception ex)
        {

            await DisplayAlert("Alert", ex.Message, "Ok");
        }
    }

    private async void Prouct_Add(object sender, EventArgs e)
    {
        try
        {
            var productName = product_name.Text.ValidateEmptyFields();
            var productCategory = product_category.Text.ValidateEmptyFields();
            var productQuantity = product_quantity.Text.ValidateEmptyFields();
           
            var productStock = stock_number.Text.ValidateEmptyFields();
            var productPrice = product_price.Text.ValidateEmptyFields();

            int QuanNumber = Convert.ToInt16(productQuantity);
            int StockNumber = Convert.ToInt16(productStock);
            double DoublePrice = Convert.ToDouble(productPrice);

            var new_product = new Product
            {
                Name = productName,
                Category = productCategory,
                Quantity = QuanNumber,
                InStock = StockNumber,
                Currency = (Currency)selected_currency.SelectedItem,
                Price = DoublePrice,

            };
            _productrepo.AddProduct(new_product);
        }

        catch (Exception ex)
        {

            await DisplayAlert("Alert", ex.Message, "Ok");
        }
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var rolesPopUp = App.Services.GetRequiredService<ChangeRolesPopup>();
        this.ShowPopupAsync(rolesPopUp);
    }

    private async void product_quantity_TextChanged(object sender, TextChangedEventArgs e)
    {

        try
        {
            ValidationExtension.NumberValidation(sender, e);
        }
        catch (Exception) {

            await DisplayAlert("Alert","Please enter number in the desired fields","Ok");
        }
    }

    private async void stock_number_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            ValidationExtension.NumberValidation(sender, e);
        }
        catch (Exception) { 

            await DisplayAlert("Alert", "Please enter number in the desired fields", "Ok");
        }
    }

    private async void price_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            ValidationExtension.DoubleValidation(sender, e);
        }
        catch (Exception)
        {

            await DisplayAlert("Alert", "Please enter number in the desired fields", "Ok");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
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
    private readonly DuplicateValidation _duplicateValidation;
    public AdminDashboard(DatabaseContext databaseContext, UserRepository repo,ProductRepository productrepo, DuplicateValidation duplicateValidation)
    {
        InitializeComponent();

        _databaseContext = databaseContext;
        _userrepo = repo;
        _productrepo = productrepo;
        _duplicateValidation = duplicateValidation;

        var enumViewModel = App.Services.GetRequiredService<EnumViewModel>();
        BindingContext = enumViewModel;

    }
    private async void Staff_Button(object sender, EventArgs e)
    {
        var enumModel = BindingContext as EnumViewModel;
        

        try
        {
            var staffName = staff_name.Text.ValidateEmptyFields();
            var staffUsername = staff_username.Text.ValidateEmptyFields();

            string NoDuplicateUsername = _duplicateValidation.DuplicateUsername(staffUsername);

            var password = pass.Text.ValidateEmptyFields();
            var confirmed_pass = confirm_pass.Text.ValidateEmptyFields();

            string password_validated = ValidationExtension.ValidatePassword(password, confirmed_pass); 

            var new_user = new AppUsers
            {
                Name = staffName,
                Username = staffUsername,
                Password = confirmed_pass,
                Roles = (Roles)staff_role.SelectedItem,
            };
            _userrepo.AddUserAsync(new_user);

            staff_name.Text = string.Empty;
            staff_username.Text = string.Empty;
            pass.Text = string.Empty;
            confirm_pass.Text = string.Empty; 
            staff_role.SelectedIndex = -1;
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

            product_name.Text = string.Empty;
            product_category.Text = string.Empty;
            product_quantity.Text= string.Empty;
            stock_number.Text = string.Empty;
            product_price.Text = string.Empty;
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

    private void staff_username_TextChanged(object sender, TextChangedEventArgs e)
    {
        
    }
    private void ShowStaffForm(object sender, EventArgs e)
    {
        StaffForm.IsVisible = true;
        ProductForm.IsVisible = false;

        UsersButton.BackgroundColor = Color.FromArgb("#E0E7FF");
        ProductButton.BackgroundColor = Colors.Transparent;
    }

    private void ShowProductForm(object sender, EventArgs e)
    {
        StaffForm.IsVisible = false;
        ProductForm.IsVisible = true;

        UsersButton.BackgroundColor = Colors.Transparent;
        ProductButton.BackgroundColor = Color.FromArgb("#E0E7FF"); 
    }
}
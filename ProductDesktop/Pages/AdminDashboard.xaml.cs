using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Validation;
using System.Text.RegularExpressions;

namespace ProductDesktop.Pages;

public partial class AdminDashboard : ContentPage
{
    private readonly DatabaseContext _databaseContext;
    public AdminDashboard(DatabaseContext databaseContext)
    {
        InitializeComponent();

        _databaseContext = databaseContext;
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
            var stockNumber = stock_number.Text.ValidateEmptyFields();


            var new_user = new Product
            {
                Name = productName,
                Category = productCategory,
                //Quantity = ,
                //Currency = ,
                //Price = ,
                //InStock = ,
            };

        }

        catch (Exception ex)
        {

            await DisplayAlert("Alert", ex.Message, "Ok");
        }
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ChangeRoles(_databaseContext));
    }

    private void product_quantity_TextChanged(object sender, TextChangedEventArgs e)
    {
        var productQuantity = e.NewTextValue.ValidateEmptyFields();

        if (!Regex.Match(e.NewTextValue, @"^[0-9]+$").Success)
        {
            var entry = sender as Entry;
            entry.Text = string.IsNullOrEmpty(e.OldTextValue) ? string.Empty : e.OldTextValue;
        }
    }
}
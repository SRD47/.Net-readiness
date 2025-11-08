using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using Serilog;

namespace ProductDesktop.Pages;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseContext _databaseContext;

	public LoginPage(DatabaseContext databaseContext,UserRepository userRepository,ProductRepository productRepository)
	{
		InitializeComponent();

        _databaseContext = databaseContext;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var signup = App.Services.GetRequiredService<SignupPage>();
		await Navigation.PushAsync(signup);
    }
    private async void ForgotPassword_Tapped(object sender, TappedEventArgs e)
    {
        
        await DisplayAlert("Forgot Password", "Redirecting to reset page...", "OK");
        var forgetPage = App.Services.GetRequiredService<ForgetPasswordPage>();
        await Navigation.PushAsync(forgetPage);

    }

    private async void OnClick(object sender, EventArgs e)
    {

        try
        {
            string username_validated = get_username.Text.ToString().ToLower().ValidateEmptyFields();
            string password_validated = get_password.Text.ToString().ToLower().ValidateEmptyFields();

            var user = _databaseContext.AppUsers.Where(u => u.Username == username_validated).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("No user exists. Please try again.");
            }
            if (user.Password != password_validated) { throw new Exception("Incorrect Password. Try Again."); }

            if (username_validated == user.Username.ToLower() && password_validated.ToLower() == user.Password)
            {
                if (user.Roles == Roles.Admin) {
                    var adminPage = App.Services.GetRequiredService<AdminDashboard>();
                    await Navigation.PushAsync(adminPage);
                }
                else if (user.Roles == Roles.OrderProcessor) { 
                    var orderPage = App.Services.GetRequiredService<OrderProcessor>();
                    await Navigation.PushAsync(orderPage);
                }
                else if (user.Roles == Roles.InventoryManager)
                {
                    var inventoryPage = App.Services.GetRequiredService<InventoryManager>();
                    await Navigation.PushAsync(inventoryPage);
                }
                else if (user.Roles == Roles.Customer)
                {
                    var customerPage = App.Services.GetRequiredService<CustomerDashboard>();
                    await Navigation.PushAsync(customerPage);
                }

                get_username.Text = string.Empty;
                get_password.Text = string.Empty;

            }
            else
                return;
        }
        catch (Exception ex) {

            await DisplayAlert("Alert", ex.Message ,"Ok");
        }
    }
}
using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;

namespace ProductDesktop.Pages;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseContext _databaseContext;

    private readonly UserRepository _userRepository;
    private readonly ProductRepository _productRepository;
	public LoginPage(DatabaseContext databaseContext,UserRepository userRepository,ProductRepository productRepository)
	{
		InitializeComponent();

        _databaseContext = databaseContext;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var signup = App.Services.GetRequiredService<SignupPage>();
		await Navigation.PushAsync(signup);
    }

    private async void OnClick(object sender, EventArgs e)
    {
        try
        {
            string username_validated = get_username.Text.ValidateEmptyFields();
            string password_validated = get_password.Text.ValidateEmptyFields();

            var user = _databaseContext.AppUsers.Where(u => u.Username == username_validated).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("No user exists. Please try again.");
            }
            if (user.Password != password_validated) { throw new Exception("Incorrect Password. Try Again."); }

            if (username_validated == user.Username && password_validated == user.Password)
            {
                if (user.Roles == Roles.Admin) {
                    var adminPage = App.Services.GetRequiredService<AdminDashboard>();
                    await Navigation.PushAsync(adminPage);
                }
                else if (user.Roles == Roles.OrderProcessor) { 
                    var customerPage = App.Services.GetRequiredService<CustomerDashboard>();
                    await Navigation.PushAsync(customerPage);
                }
                else if (user.Roles == Roles.InventoryManager)
                {
                    var customerPage = App.Services.GetRequiredService<CustomerDashboard>();
                    await Navigation.PushAsync(customerPage);
                }
                else if (user.Roles == Roles.Customer)
                {
                    var customerPage = App.Services.GetRequiredService<CustomerDashboard>();
                    await Navigation.PushAsync(customerPage);
                }
            }
            else
                return;
        }
        catch (Exception ex) {

            await DisplayAlert("Alert", ex.Message ,"Ok");
        }
    }
}
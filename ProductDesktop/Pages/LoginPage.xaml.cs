using ProductDesktop.Database;
using ProductDesktop.Validation;

namespace ProductDesktop.Pages;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseContext _databaseContext;

	public LoginPage(DatabaseContext databaseContext)
	{
		InitializeComponent();

        _databaseContext = databaseContext;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new SignupPage());
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
                if (user.Roles == Roles.Admin) await Navigation.PushAsync(new AdminDashboard());
                else if (user.Roles == Roles.OrderProcessor) await Navigation.PushAsync(new CustomerDashboard());
                else if (user.Roles == Roles.InventoryManager) await Navigation.PushAsync(new CustomerDashboard());
                else if(user.Roles == Roles.Customer) await Navigation.PushAsync(new CustomerDashboard());
            }
            else
                return;
        }
        catch (Exception ex) {

            await DisplayAlert("Alert", ex.Message ,"Ok");
        }
    }
}
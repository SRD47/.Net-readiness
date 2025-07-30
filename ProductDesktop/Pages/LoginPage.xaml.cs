namespace ProductDesktop.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

		var username = get_username.GetValue;
		var password = get_password.GetValue;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new SignupPage());
    }
}
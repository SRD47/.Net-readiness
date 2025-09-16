using ProductDesktop.Entities;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class CustomerDashboard : ContentPage
{

	public CustomerDashboard()
	{
		InitializeComponent();
		BindingContext = App.Services.GetRequiredService<StaffViewModel>();
	}

    private void Cart_Clicked(object sender, EventArgs e)
    {
		var button = sender as Button;
		var product = button.CommandParameter as Product;



		if (product != null && BindingContext is StaffViewModel viewModel)
		{
			viewModel.SelectedProduct.Add(product);

			viewModel.TotalAmount = viewModel.SelectedProduct.Sum(p => p.Price);
        }
    }

    private async void LogoutBtn(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alert", "Do you want to logout?", "Yes", "No");

        if (answer)
        {

            var login = App.Services.GetRequiredService<LoginPage>();
            await Navigation.PushAsync(login);
        }
        else
        {
            return;
        }
    }
}
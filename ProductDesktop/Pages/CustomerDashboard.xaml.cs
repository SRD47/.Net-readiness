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
}
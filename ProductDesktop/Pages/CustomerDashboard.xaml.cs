using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class CustomerDashboard : ContentPage
{
	public CustomerDashboard()
	{
		InitializeComponent();
		BindingContext = App.Services.GetRequiredService<StaffViewModel>();

	}
}
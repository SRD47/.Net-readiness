using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class ProductsTablePage : ContentPage
{
	public ProductsTablePage()
	{
		InitializeComponent();

		var tableModel = App.Services.GetRequiredService<StaffViewModel>();
		BindingContext = tableModel;
	}
}
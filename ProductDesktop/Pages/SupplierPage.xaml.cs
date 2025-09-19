using ProductDesktop.ViewModel;
using CommunityToolkit.Maui.Extensions;


namespace ProductDesktop.Pages;

public partial class SupplierPage 
{
	public SupplierPage()
	{
		InitializeComponent();

		var mainModel = App.Services.GetRequiredService<StaffViewModel>();
		BindingContext = mainModel;
	}

    private async void Add_Supplier(object sender, EventArgs e)
    {
        var addSupplier = App.Services.GetRequiredService<AddSupplierPopup>();
        await  Application.Current.MainPage.ShowPopupAsync(addSupplier);
    }
}
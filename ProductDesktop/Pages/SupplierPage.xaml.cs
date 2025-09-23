using ProductDesktop.ViewModel;
using CommunityToolkit.Maui.Extensions;
using ProductDesktop.Entities;


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

    private async void Order_Btn(object sender, EventArgs e)
    {

        var button = sender as Button;
        var supplier = button.BindingContext as Supplier;

        if (supplier != null) {

            var OrderPopup = App.Services.GetRequiredService<OrderPagePopup>();
            OrderPopup.GetSupplierDetails(supplier);
            await Application.Current.MainPage.ShowPopupAsync(OrderPopup);
        }
    }
}
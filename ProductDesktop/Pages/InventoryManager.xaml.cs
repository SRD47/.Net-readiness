using CommunityToolkit.Maui.Extensions;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.ViewModel;


namespace ProductDesktop.Pages;

public partial class InventoryManager : ContentPage
{
    private readonly DatabaseContext _context;
	public InventoryManager(DatabaseContext context)
	{

        InitializeComponent();


        _context = context;

		var inventoryView = App.Services.GetRequiredService<StaffViewModel>();
        BindingContext = inventoryView;

        DashboardBtn.Style = (Style)Resources["SidebarButtonSelected"];
    }

    private void Edit_Button(object sender, EventArgs e)
    {
                
    }
    private void Delete_Button(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var product = button.BindingContext as Product;

        if (product != null) {

            var _dbcontext = App.Services.GetRequiredService<DatabaseContext >();


            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChangesAsync();

            var inventoryView = App.Services.GetRequiredService<StaffViewModel>();
            inventoryView.ProductList.Remove(product);
        }
    }
    private void DashboardBtn_Clicked(object sender, EventArgs e)
    {
        DashboardSection.IsVisible = true;
        ProductsSection.IsVisible = false;
        SuppliersSection.IsVisible = false;

        DashboardBtn.Style = (Style)Resources["SidebarButtonSelected"];
        ProductsBtn.Style = (Style)Resources["SidebarButton"];
        SuppliersBtn.Style = (Style)Resources["SidebarButton"];
    }

    private void ProductsBtn_Clicked(object sender, EventArgs e)
    {
        DashboardSection.IsVisible = false;
        ProductsSection.IsVisible = true;
        SuppliersSection.IsVisible = false;

        ProductsBtn.Style = (Style)Resources["SidebarButtonSelected"];
        DashboardBtn.Style = (Style)Resources["SidebarButton"];
        SuppliersBtn.Style = (Style)Resources["SidebarButton"];
    }


    private void SuppliersBtn_Clicked(object sender, EventArgs e)
    {
        DashboardSection.IsVisible = false;
        ProductsSection.IsVisible = false;
        SuppliersSection.IsVisible = true;

        SuppliersBtn.Style = (Style)Resources["SidebarButtonSelected"];
        DashboardBtn.Style = (Style)Resources["SidebarButton"];
        ProductsBtn.Style = (Style)Resources["SidebarButton"];
    }

    private void ShowProductPopup(object sender, EventArgs e)
    {
        var addproduct = App.Services.GetRequiredService<AddProductPopup>();
        this.ShowPopup(addproduct);
    }

    private async void LogoutBtn_Clicked(object sender, EventArgs e)
    {
       bool answer =  await DisplayAlert("Alert", "Do you want to logout?","Yes","No");

        if (answer) {
            
            var login = App.Services.GetRequiredService<LoginPage>();
            await Navigation.PushAsync(login);
        }
        else
        {
            return;
        }
    }

}
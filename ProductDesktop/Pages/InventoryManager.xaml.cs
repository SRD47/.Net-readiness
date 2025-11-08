using CommunityToolkit.Maui.Extensions;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class InventoryManager : ContentPage
{
    private readonly DatabaseContext _context;
    private readonly OrderRepo _repo;

    public InventoryManager(DatabaseContext context,OrderRepo repo)
    {
        InitializeComponent();

        _context = context;
        _repo = repo;

        var mainView = App.Services.GetRequiredService<MainViewModel>();
        BindingContext = mainView;

        DashboardBtn.Style = (Style)Resources["SidebarButtonSelected"];

        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        DashboardPgData();
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

    private async void LogoutBtn_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alert", "Do you want to logout?", "Yes", "No");
        if (answer)
        {
            var login = App.Services.GetRequiredService<LoginPage>();
            await Navigation.PushAsync(login);
        }
    }

    private void DashboardPgData()
    {
        int total = _context.Products.Count();
        TotalProductsNum.Text = $"Total Products: {total}";

        int lowStock = _context.Products.Count(p => p.Stock <= 5);
        LowStockNum.Text = $"Low Stock Items: {lowStock}";

        int pending = _context.Orders.Count(o => o.OrderStatus == OrderStatus.Pending);
        PendingOrderNum.Text = $"Pending Orders: {pending}";
    }

    private async void ReorderBtn_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var order = button?.BindingContext as Order;

        var ReOrder = new Order
        {
            
            ProductName = order.ProductName,
            Quantity = order.Quantity,
            OrderStatus = OrderStatus.Pending,
            OrderDate = DateOnly.FromDateTime(DateTime.Today),
            ExpectedDeliveryDate = DateOnly.FromDateTime(DateTime.Today).AddDays(7),
            SupplierId = order.SupplierId,
            Notes = order.Notes,

        };

        _repo.AddOrder(ReOrder);

        var model = App.Services.GetRequiredService<StaffViewModel>();
        model.OrdersList.Add(ReOrder);

    }

    private void OrdersPanel_TextChanged(object sender, TextChangedEventArgs e)
    {
        var modal = App.Services.GetRequiredService<StaffViewModel>();
        modal.FilterOrders(e.NewTextValue);
    }

    private async void Order_Delete(object sender, EventArgs e)
    {

    }

}

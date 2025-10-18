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

    private void ShowProductPopup(object sender, EventArgs e)
    {
        var addProduct = App.Services.GetRequiredService<AddProductPopup>();
        this.ShowPopup(addProduct);
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

    private void Edit_Button(object sender, EventArgs e)
    {
       
    }

    private async void Delete_Button(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var product = button?.BindingContext as Product;

        if (product != null)
        {
            bool confirm = await DisplayAlert("Confirm Delete", $"Delete {product.Name}?", "Yes", "No");
            if (!confirm) return;

            var db = App.Services.GetRequiredService<DatabaseContext>();
            db.Products.Remove(product);
            await db.SaveChangesAsync();

            var inventoryView = App.Services.GetRequiredService<StaffViewModel>();
            inventoryView.ProductList.Remove(product);
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

        await _context.Orders.AddAsync(ReOrder);
        _context.SaveChangesAsync();

        var model = App.Services.GetRequiredService<StaffViewModel>();
        model.OrdersList.Add(ReOrder);

    }

    private void OrdersPanel_TextChanged(object sender, TextChangedEventArgs e)
    {
        var modal = App.Services.GetRequiredService<StaffViewModel>();
        modal.FilterOrders(e.NewTextValue);
    }
}

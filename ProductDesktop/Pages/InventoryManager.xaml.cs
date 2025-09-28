using CommunityToolkit.Maui.Extensions;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.ViewModel;
using Microcharts;
using SkiaSharp;

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


    protected override void OnAppearing()
    {
        base.OnAppearing();
        DashboardPgData();
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

    private async  void DashboardPgData()
    {
        int Total =  _context.Products.Count();
        TotalProductsNum.Text = $"Total Products: {Total}";

        var LowStockProducts = _context.Products.Where(a => a.Stock <= 5);
        int LowStock = LowStockProducts.Count();
        LowStockNum.Text = $"Low Stock Items: {LowStock}";

        var PendingOrders = _context.Orders.Where(a => a.OrderStatus == OrderStatus.Pending);
        int PendingNum = PendingOrders.Count();
        PendingOrderNum.Text = $"Pending Orders: {PendingNum}";

        var chart = GetPurchaseChart();
        PurchaseChart.Chart = chart;
    }

    private Chart GetPurchaseChart()
    {
        try
        {
            var purchaseData = _context.Orders
                .GroupBy(p => p.ProductName)
                .Select(g => new {
                    Product = g.Key,
                    TotalQuantity = g.Sum(p => p.Quantity)
                })
                .Where(p => p.TotalQuantity > 0)  // Only positive quantities
                .ToList();

            if (purchaseData.Count == 0)
            {
                // Return an empty chart or null if no data
                return new BarChart
                {
                    Entries = new List<ChartEntry>(),
                    LabelTextSize = 18,
                    BackgroundColor = SKColors.White
                };
            }

            var entries = new List<ChartEntry>();
            foreach (var p in purchaseData)
            {
                if (SKColor.TryParse("#3B82F6", out var color))
                {
                    entries.Add(new ChartEntry(p.TotalQuantity)
                    {
                        Label = p.Product,
                        ValueLabel = p.TotalQuantity.ToString(),
                        Color = color
                    });
                }
                else
                {
                    // fallback color if parsing fails
                    entries.Add(new ChartEntry(p.TotalQuantity)
                    {
                        Label = p.Product,
                        ValueLabel = p.TotalQuantity.ToString(),
                        Color = SKColors.Blue
                    });
                }
            }

            return new BarChart
            {
                Entries = entries,
                LabelTextSize = 28,
                BackgroundColor = SKColors.White
            };
        }
        catch (Exception ex)
        {
            // Log or handle the error
            Console.WriteLine($"Chart generation failed: {ex.Message}");

            // Return an empty chart as fallback
            return new BarChart
            {
                Entries = new List<ChartEntry>(),
                LabelTextSize = 18,
                BackgroundColor = SKColors.White
            };
        }
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
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.Input;
using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class ProductPage 
{
    private readonly DatabaseContext _db;

    public ProductPage() : this(App.Services.GetRequiredService<DatabaseContext>()){}
    public ProductPage(DatabaseContext db)
	{
		InitializeComponent();

        _db = db;

        BindingContext = App.Services.GetRequiredService<EnumViewModel>();
	}

    private void ShowProductPopup(object sender, EventArgs e)
    {
        var addProduct = App.Services.GetRequiredService<AddProductPopup>();
        App.Current.MainPage.ShowPopup(addProduct);
    }


    private async void ViewEditProduct_Btn(object sender, EventArgs e)
    {

        var btn = sender as Button;
        var product = btn.BindingContext as Product;

        var popup = App.Services.GetRequiredService<EditProductPopup>();
        popup.LoadDetails(product);
        await App.Current.MainPage.ShowPopupAsync(popup);
    }

    private async void Delete_Button(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var product = button?.BindingContext as Product;

        if (product != null)
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Confirm Delete", $"Delete {product.Name}?", "Yes", "No");
            if (!confirm) return;

            var db = App.Services.GetRequiredService<DatabaseContext>();
            db.Products.Remove(product);
            await db.SaveChangesAsync();

            var inventoryView = App.Services.GetRequiredService<StaffViewModel>();
            inventoryView.ProductList.Remove(product);
        }
    }
}
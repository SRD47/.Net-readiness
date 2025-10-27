using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class EditProductPopup 
{

	private readonly DatabaseContext _db;

	public EditProductPopup(DatabaseContext db)
	{
		InitializeComponent();

		_db = db;
        BindingContext = App.Services.GetRequiredService<EnumViewModel>();
	}

    public void LoadDetails(Product product)
    {
        BindingContext = product;
    }

    private void CancelBtn(object sender, EventArgs e)
    {
        Name_Entry.Text = String.Empty;

    }

    private async void SaveBtn(object sender, EventArgs e)
    {
        try
        {
            var product = BindingContext as Product;
            if (product == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No supplier selected.", "OK");
                return;
            }

            _db.Update(product);
            await _db.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
        }
    }
    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        await CloseAsync(); 
    }
}
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using ProductDesktop.ViewModel;
using Serilog;

namespace ProductDesktop.Pages;

public partial class AddProductPopup 
{
    private readonly ProductRepository _prepo;
	public AddProductPopup(ProductRepository prepo) 
	{
		InitializeComponent();

        _prepo = prepo;

		var EnumBinding = App.Services.GetRequiredService<EnumViewModel>();
		BindingContext = EnumBinding;
	}

    private async void Product_Add(object sender, EventArgs e)
    {
        try
        {
            var proName = product_name.Text.ValidateEmptyFields();
            var stockNum = stock_number.Text.ValidateEmptyFields();
            var proPrice = product_price.Text.ValidateEmptyFields();

            int stockInt = Convert.ToInt32(stockNum);
            double priceDouble = Convert.ToDouble(proPrice);

            var newProduct = new Product
            {
                Name = proName,
                Category = (Category)selected_category.SelectedItem,
                Stock = stockInt,
                Currency = (Currency)selected_currency.SelectedItem,
                Price = priceDouble,
            };

             _prepo.AddProduct(newProduct);


            product_name.Text = string.Empty;
            stock_number.Text = string.Empty;
            product_price.Text = string.Empty;


        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void stockNum(object sender, TextChangedEventArgs e)
    {
        try
        {
            ValidationExtension.NumberValidation(sender, e);
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid data in the fields", "OK");

        }
    }

    private async void priceDouble(object sender, TextChangedEventArgs e)
    {
        try
        {
            ValidationExtension.DoubleValidation(sender, e);
        }
        catch (Exception)
        {

            await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid data in the fields", "OK");

        }
    }
    private void CloseButton(object sender, EventArgs e)
    {
		CloseAsync();
    }
}
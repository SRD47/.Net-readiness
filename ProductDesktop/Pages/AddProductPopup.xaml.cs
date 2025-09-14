using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using ProductDesktop.ViewModel;

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

    private async void Prouct_Add(object sender, EventArgs e)
    {
        try
        {
            var productName = product_name.Text.ValidateEmptyFields();
            var productCategory = product_category.Text.ValidateEmptyFields();


            var productQuantity = product_quantity.Text.ValidateEmptyFields();

            var productStock = stock_number.Text.ValidateEmptyFields();
            var productPrice = product_price.Text.ValidateEmptyFields();

            int QuanNumber = Convert.ToInt16(productQuantity);
            int StockNumber = Convert.ToInt16(productStock);
            double DoublePrice = Convert.ToDouble(productPrice);

            var new_product = new Product
            {
                Name = productName,
                Category = productCategory,
                Quantity = QuanNumber,
                InStock = StockNumber,
                Currency = (Currency)selected_currency.SelectedItem,
                Price = DoublePrice,

            };
            _prepo.AddProduct(new_product);

            product_name.Text = string.Empty;
            product_category.Text = string.Empty;
            product_quantity.Text = string.Empty;
            stock_number.Text = string.Empty;
            product_price.Text = string.Empty;
        }

        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alert",ex.Message,"Ok");
        }
    }

    private void CloseButton(object sender, EventArgs e)
    {
		CloseAsync();
    }
}
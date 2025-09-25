using ProductDesktop.Database;
using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class OrderPagePopup 
{
	private readonly DatabaseContext _db;
	private readonly OrderRepo _orderRepo;
	public OrderPagePopup(DatabaseContext db,OrderRepo orderRepo)
	{
		InitializeComponent();

		_db = db;
		_orderRepo = orderRepo;

		BindingContext = App.Services.GetRequiredService<EnumViewModel>();
	}

	public void GetSupplierDetails(Supplier supplier)
	{
		SupplierNameLabel.Text = supplier.SupplierName;
		CategoryEntry.Text = supplier.Category.ToString();

	}

    private async void PlaceOrderButton_Clicked(object sender, EventArgs e)
    {
		try
		{

			string CheckSuppName = SupplierNameLabel.Text;

			string Pname = ProductNameEntry.Text.ValidateEmptyFields();

			string QuanS= QuantityEntry.Text;
			int QuanInt = Convert.ToInt32(QuanS);

			DateOnly OrderDate = DateOnly.FromDateTime(OrderDatePicker.Date);
			DateOnly Expectdelivery = DateOnly.FromDateTime(DeliveryDatePicker.Date);
			string notes = OrderNotesEditor.Text;

			var IdGet = _db.Suppliers.FirstOrDefault(a => a.SupplierName == CheckSuppName);
			var IDConnect = IdGet.SupplierId;

			var NewOrder = new Order
			{
				ProductName = Pname,
				Quantity = QuanInt,
                Notes = notes,
				OrderStatus = (OrderStatus)OrderStatusPicker.SelectedItem,
                OrderDate = OrderDate,
				ExpectedDeliveryDate = Expectdelivery,
				SupplierId = IDConnect,
			};

			_orderRepo.AddOrder(NewOrder);

			ProductNameEntry.Text = string.Empty;
			QuantityEntry.Text = string.Empty;
			OrderNotesEditor.Text = string.Empty;

        }
		catch (Exception ex) {

			await App.Current.MainPage.DisplayAlert("Caution", ex.Message, "Ok");
		}
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {

    }

	private void QuanInt(object sender,TextChangedEventArgs e)
	{
		try
		{
			ValidationExtension.NumberValidation(sender, e);
		}
		catch
		{
			App.Current.MainPage.DisplayAlert("Caution", "Please enter required data in the fields", "Ok");
		}
	}
}
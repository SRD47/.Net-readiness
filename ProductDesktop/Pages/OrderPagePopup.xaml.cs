using ProductDesktop.Entities;

namespace ProductDesktop.Pages;

public partial class OrderPagePopup 
{
	public OrderPagePopup()
	{
		InitializeComponent();
	}

	public void GetSupplierDetails(Supplier supplier)
	{
		SupplierNameLabel.Text = supplier.SupplierName;
		CategoryEntry.Text = supplier.Category.ToString();

	}

    private void PlaceOrderButton_Clicked(object sender, EventArgs e)
    {

    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {

    }
}
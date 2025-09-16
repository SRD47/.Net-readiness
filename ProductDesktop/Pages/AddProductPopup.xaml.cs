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
            
        }
        catch
        {

        }
    }

    private void CloseButton(object sender, EventArgs e)
    {
		CloseAsync();
    }
}
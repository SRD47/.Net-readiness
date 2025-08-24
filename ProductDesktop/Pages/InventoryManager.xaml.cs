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

		var inventoryView = App.Services.GetRequiredService<StaffViewModel>();
        BindingContext = inventoryView;

		
	}

    private void Edit_Button(object sender, EventArgs e)
    {
        
    }
    private async void Delete_Button(object sender, EventArgs e)
    {
        
    }
}
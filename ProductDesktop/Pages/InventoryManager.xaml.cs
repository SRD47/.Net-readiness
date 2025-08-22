using ProductDesktop.Database;
using ProductDesktop.ViewModel;
using System.Threading.Tasks;

namespace ProductDesktop.Pages;

public partial class InventoryManager : ContentPage
{
    private readonly DatabaseContext _context;
	public InventoryManager(DatabaseContext context)
	{

        InitializeComponent();


        _context = context;

		var staffViewModel = App.Services.GetRequiredService<StaffViewModel>();
        BindingContext = staffViewModel;

		
	}

    private void Edit_Button(object sender, EventArgs e)
    {
        
    }
    private async void Delete_Button(object sender, EventArgs e)
    {
        
    }
}
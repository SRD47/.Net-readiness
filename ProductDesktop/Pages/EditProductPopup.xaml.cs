using ProductDesktop.Database;
using ProductDesktop.ViewModel;
using System.Threading.Tasks;

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

    private void CancelBtn(object sender, EventArgs e)
    {
        Name_Entry.Text = String.Empty;

    }

    private void SaveBtn(object sender, EventArgs e)
    {

    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        await CloseAsync(); 
    }
}
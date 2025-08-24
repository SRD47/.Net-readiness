using ProductDesktop.Database;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class ChangeRolesPopup
{
    private readonly DatabaseContext _dbcontext;
    public ChangeRolesPopup(DatabaseContext dbcontext,MainViewModel mainViewModel)
    {
        InitializeComponent();

        _dbcontext = dbcontext;

        BindingContext = mainViewModel;
    }

    private void Close_Popup(object sender, EventArgs e)
    {
        CloseAsync();
    }

    private void Update_Clicked(object sender, EventArgs e)
    {

    }
}

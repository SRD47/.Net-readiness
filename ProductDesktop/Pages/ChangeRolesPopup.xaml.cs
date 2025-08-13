using ProductDesktop.Database;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class ChangeRolesPopup
{
    private readonly DatabaseContext _dbcontext;
    public ChangeRolesPopup(DatabaseContext dbcontext)
    {
        InitializeComponent();

        _dbcontext = dbcontext;

        var staffViewModel = App.Services.GetService<StaffViewModel>();
        BindingContext = staffViewModel;

    }

    private void Close_Popup(object sender, EventArgs e)
    {
        CloseAsync();
    }
}

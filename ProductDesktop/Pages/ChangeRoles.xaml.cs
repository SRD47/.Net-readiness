using ProductDesktop.Database;
using ProductDesktop.ViewModel;

namespace ProductDesktop.Pages;

public partial class ChangeRoles : ContentPage
{
    private readonly DatabaseContext _dbcontext;
    public ChangeRoles(DatabaseContext dbcontext)
    {
        InitializeComponent();

        _dbcontext = dbcontext;

        BindingContext = new StaffViewModel(_dbcontext);
        _dbcontext = dbcontext;
    }
}

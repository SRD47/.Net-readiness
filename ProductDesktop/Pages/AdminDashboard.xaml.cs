using ProductDesktop.Database;

namespace ProductDesktop.Pages;

public partial class AdminDashboard : ContentPage
{
    private readonly DatabaseContext _databaseContext;
    public AdminDashboard(DatabaseContext databaseContext)
	{
		InitializeComponent();

        _databaseContext = databaseContext;
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new ChangeRoles(_databaseContext));
    }
}
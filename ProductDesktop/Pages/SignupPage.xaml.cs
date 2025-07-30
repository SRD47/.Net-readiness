using ProductDesktop.Database;
using ProductDesktop.Repository;

namespace ProductDesktop.Pages;

public partial class SignupPage : ContentPage
{
	private readonly UserRepository _userRepo;
	
	public SignupPage()
	{
		InitializeComponent();

		var dbcontext = new DatabaseContext();
		_userRepo = new UserRepository(dbcontext);
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
		var NewUser = new Users
		{
			Name = nameLabel.Text.ToString(),
			Username = username.Text.ToString(),
			Password = password.Text.ToString(),
			Roles = (Roles)4,
	    };
		_userRepo.AddUser(NewUser);

    }
}
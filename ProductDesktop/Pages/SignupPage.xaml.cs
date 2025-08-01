using ProductDesktop.Database;
using ProductDesktop.Repository;
using ProductDesktop.Validation;

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
    private async void Button_Clicked(object sender, EventArgs e)
    {

		try
		{
			string nameValidated = nameLabel.Text.ValidateEmptyFields();
            string usernameValidated = username.Text.ValidateEmptyFields();
            string PassValidated =password.Text.ValidateEmptyFields();
            string confirmPassValidated =confirm_password.Text.ValidateEmptyFields();

			string password_validated = ValidationExtension.ValidatePassword(password.Text, confirm_password.Text);

			var NewUser = new Users
			{
				Name = nameValidated,
				Username = usernameValidated,
				Password = confirmPassValidated,
				Roles = (Roles)4,
			};
			_userRepo.AddUser(NewUser);
		}

		catch (Exception ex) { 
			await DisplayAlert("Alert", ex.Message, "Ok"); 
		}
    }
}
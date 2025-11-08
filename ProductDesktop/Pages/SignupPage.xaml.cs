using ProductDesktop.Entities;
using ProductDesktop.Validation;
using ProductDesktop.Repository;
using Serilog;

namespace ProductDesktop.Pages;

public partial class SignupPage : ContentPage
{
    private readonly UserRepository _userRepo;

    public SignupPage(UserRepository repository)
    {
        InitializeComponent();
        _userRepo = repository;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {

        try
        {
            string nameValidated = nameLabel.Text.ValidateEmptyFields().Trim();
            string usernameValidated = username.Text.ValidateEmptyFields().Trim();
            string PassValidated = password.Text.ValidateEmptyFields().Trim();
            string confirmPassValidated = confirm_password.Text.ValidateEmptyFields().Trim();

            string password_validated = ValidationExtension.ValidatePassword(password.Text, confirm_password.Text);

            //Remove Duplication

            var duplicateUsername = App.Services.GetRequiredService<DuplicateValidation>();
            duplicateUsername.DuplicateUsername(usernameValidated);


            var NewUser = new AppUsers
            {
                Name = nameValidated,
                Username = usernameValidated,
                Password = confirmPassValidated,
                Roles = Roles.Customer,
            };

             _userRepo.AddUserAsync(NewUser);
            Log.Information($"{nameValidated} user signed up.");

            nameLabel.Text = string.Empty;
            username.Text = string.Empty;
            password.Text = string.Empty;
            confirm_password.Text = string.Empty;

            await DisplayAlert("Success", "Account created successfully!", "OK");

            var loginPage = App.Services.GetRequiredService<LoginPage>();
            await Navigation.PushAsync(loginPage);
        }

        catch (Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "Ok");
        }
    }
    private async void Login_Tapped(object sender, TappedEventArgs e)
    {
        
        var loginPage = App.Services.GetRequiredService<LoginPage>();
        await Navigation.PushAsync(loginPage);
    }

}
using ProductDesktop.Validation;

namespace ProductDesktop.Pages;

public partial class ForgetPasswordPage : ContentPage
{
	public ForgetPasswordPage()
	{
		

		InitializeComponent();
	}

    private async void submit_btn(object sender, EventArgs e)
    {
        try
        {
            var nameEty = name_entry.Text.ValidateEmptyFields();
            var username = username_entry.Text.ValidateEmptyFields();



            var pass = pass_entry.Text.ValidateEmptyFields();
            var RePass = re_pass.Text.ValidateEmptyFields();

            var validatedBothPass = ValidationExtension.ValidatePassword(pass, RePass);

            
        }
        catch (Exception ex) {

            await DisplayAlert("Alert", ex.Message, "Ok");
        }

    }
}
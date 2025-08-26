using ProductDesktop.Database;
using ProductDesktop.Validation;

namespace ProductDesktop.Pages;

public partial class ForgetPasswordPage : ContentPage
{
    private readonly DatabaseContext _context;
	public ForgetPasswordPage(DatabaseContext context)
	{
		InitializeComponent();

        _context = context ;
	}

    private async void submit_btn(object sender, EventArgs e)
    {
        try
        {
            var nameEty = name_entry.Text.ValidateEmptyFields();
            var username = username_entry.Text.ValidateEmptyFields();

            var checkName = _context.AppUsers.FirstOrDefault(p => p.Name == nameEty);

            var pass = pass_entry.Text.ValidateEmptyFields();
            var RePass = re_pass.Text.ValidateEmptyFields();

            var validatedBothPass = ValidationExtension.ValidatePassword(pass, RePass);

            if (checkName.Name == nameEty && checkName.Username == username) {

                checkName.Password = pass;
                _context.SaveChangesAsync();

            }
            else
            {
                throw new Exception("Please add valid credentials.");
            }
        }
        catch (Exception ex) {

            await DisplayAlert("Alert", ex.Message, "Ok");
        }

    }
}
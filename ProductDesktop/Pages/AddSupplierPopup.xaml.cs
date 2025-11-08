using ProductDesktop.Entities;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using ProductDesktop.ViewModel;
using Serilog;


namespace ProductDesktop.Pages;

public partial class AddSupplierPopup 
{
    private readonly SupplierRepo _repo;
	public AddSupplierPopup(SupplierRepo repo)
	{

		InitializeComponent();

        _repo = repo;

        var enumModel = App.Services.GetRequiredService<EnumViewModel>();
        BindingContext = enumModel;
	}

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
		CloseAsync();
    }

    private void CancelButton(object sender, EventArgs e)
    {
        SupplierNameEntry.Text = String.Empty;
        ContactPersonEntry.Text = String.Empty;
        PhoneNumberEntry.Text = String.Empty;
        EmailEntry.Text = String.Empty;
        DescriptionEditor.Text = String.Empty;
    }

    private async void AddSupplier(object sender, EventArgs e)
    {
        try
        {
            var supplierName = SupplierNameEntry.Text.ValidateEmptyFields();
            var supplierPerson = ContactPersonEntry.Text.ValidateEmptyFields();
            var Phone = PhoneNumberEntry.Text.ValidateEmptyFields();
            var Email = EmailEntry.Text.ValidateEmptyFields();
            var Description = DescriptionEditor.Text.ValidateEmptyFields();


            //EMAIL ADDRESS DB VALIDATION


            var NewSupplier = new Supplier
            {
                SupplierName = supplierName,
                ContactPerson = supplierPerson,
                PhoneNumber = Phone,
                Email = Email,
                Category = (Category)CategoryPicker.SelectedItem,
                Description = Description,
            };

             _repo.AddSupplier(NewSupplier);

            SupplierNameEntry.Text = String.Empty;
            ContactPersonEntry.Text = String.Empty;
            PhoneNumberEntry.Text = String.Empty;
            EmailEntry.Text = String.Empty;
            DescriptionEditor.Text = String.Empty;

            await CloseAsync();


        }
        catch (Exception ex)
        {

            await App.Current.MainPage.DisplayAlert("Caution", ex.Message, "Ok");
        }
    }
}
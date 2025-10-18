using ProductDesktop.Database;
using ProductDesktop.Validation;

namespace ProductDesktop.Pages;

public partial class EditSupplierPopup 
{
	private readonly DatabaseContext _context;
	public EditSupplierPopup(DatabaseContext context)
	{
		InitializeComponent();

		_context = context;
	}

    private void Cancel_Btn(object sender, EventArgs e)
    {
        SupplierName_Entry.Text = string.Empty;
        ContactPerson_Entry.Text = string.Empty;
        PhoneNumber_Entry.Text = string.Empty;
        Email_Entry.Text = string.Empty;
        Description_Entry.Text = string.Empty;
    }

    private void Save_Btn(object sender, EventArgs e)
    {
        var SuppName = SupplierName_Entry.Text.ValidateEmptyFields();
        var ContactPerson = ContactPerson_Entry.Text.ValidateEmptyFields();
    }
}
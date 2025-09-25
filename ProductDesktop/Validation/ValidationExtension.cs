using System.Text.RegularExpressions;

namespace ProductDesktop.Validation
{
    public static class ValidationExtension
    {
       public static string ValidateEmptyFields(this string field)
       {
            if (string.IsNullOrEmpty(field))
                throw new Exception("Please enter the required information");
            else
                return field.ToString();
       }
       
       public static string ValidatePassword(string pass, string pass_confirm)
       {
            if (pass != pass_confirm)
                throw new Exception("Please enter same password in both fields");
            else
                return pass;
       }

        public static void NumberValidation(object sender, TextChangedEventArgs e)
        {
            var entryField = e.NewTextValue.ValidateEmptyFields();

            if (!Regex.IsMatch(e.NewTextValue, @"^[0-9]+$"))
            {   
                var entry = sender as Entry;
                entry.Text = string.IsNullOrEmpty(e.OldTextValue) ? string.Empty : e.OldTextValue;
            }
        }

        public static void DoubleValidation(object sender, TextChangedEventArgs e) { 
        
            if(!Regex.IsMatch(e.NewTextValue, @"^\d*\.?\d*$"))
            {
                var entry = sender as Entry;
                entry.Text = string.IsNullOrEmpty(e.OldTextValue) ? string.Empty: e.OldTextValue;
            }
        }

    }
}

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
    }
}

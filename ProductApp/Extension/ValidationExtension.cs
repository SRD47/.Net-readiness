namespace ProductApp.Extension
{
    public static class ValidationExtension
    {
        
        public static string ValidateProName(string proName)
        {

            if (string.IsNullOrEmpty(proName.Trim())) return "Cannot be null";

            if (proName.Trim().Length < 5 || proName.Trim().Length > 20) return "Please enter product name within 5 and 20 characters";

            return null;
        }
    }
}

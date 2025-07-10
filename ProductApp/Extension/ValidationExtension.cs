using ProductApp.Database;

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

        public static int? ParseInt(string num)
        {
            if(!string.IsNullOrEmpty(num) && int.TryParse(num, out int finalResult))
                return finalResult;
            return null;
        }

        public static decimal? ParseDecimal(string num)
        {
            if(!string.IsNullOrEmpty(num) && decimal.TryParse(num , out decimal finalResult))
                return finalResult;
            return null;
        }
    }
}

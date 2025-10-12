using ProductDesktop.Entities;
using System.Globalization;

namespace ProductDesktop.Converter
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not OrderStatus status)
                return Colors.Gray;

            return status switch
            {
                OrderStatus.Pending => Color.FromArgb("#FBBF24"),      
                OrderStatus.Processing => Color.FromArgb("#3B82F6"),   
                OrderStatus.Shipped => Color.FromArgb("#2563EB"),      
                OrderStatus.Delivered => Color.FromArgb("#10B981"),    
                OrderStatus.Cancelled => Color.FromArgb("#EF4444"),    
                OrderStatus.Returned => Color.FromArgb("#6B7280"),     
                _ => Colors.Gray,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}


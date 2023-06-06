using System.Globalization;

namespace GraduationMVVM.Converters
{
    internal class ColorConverter
    {
    }
    public class StringtoColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isActive = (bool)value;

            if (isActive == true)
                return Colors.Green;
            else
                return Colors.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

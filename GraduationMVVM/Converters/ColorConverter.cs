using System.Drawing;
using System.Globalization;
using Color = Microsoft.Maui.Graphics.Color;

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
    internal class FrameListColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Id = (int)value;

            if (Id % 2 == 0)
                return Color.FromArgb("#9999ff"); 
            else
                return Color.FromArgb("#CCE5FF"); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class FrameListTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Id = (int)value;

            if (Id % 2 == 0)
                return Colors.White;
            else
                return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

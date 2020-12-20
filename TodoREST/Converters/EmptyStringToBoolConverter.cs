using System;
using System.Globalization;
using Xamarin.Forms;

namespace CryptoGrabber
{

    // [ValueConversion(typeof(DateTime), typeof(bool))]
    public class EmptyStringToBoolConverter : IValueConverter
    {

        // checks whether a given String (value) is empty or not (i.e. has Length == 0) and, if so, returns "false" else "true"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            string valueString = value.ToString();
            int i = valueString.Length;

            if (i > 0)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
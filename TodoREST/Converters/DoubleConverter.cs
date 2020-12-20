using System;
using System.Globalization;
using Xamarin.Forms;

namespace CryptoGrabber
{

    // [ValueConversion(typeof(DateTime), typeof(bool))]
    public class DoubleConverter : IValueConverter
    {

        // checks whether a given Double (value) is greater than the parameter or not and, if so, returns "true" else "false"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            Double _value = (Double)value;
            Double _parameter = (Double)parameter;

            if (_value > _parameter)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
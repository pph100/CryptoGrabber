using System;
using System.Globalization;
using Xamarin.Forms;

namespace CryptoGrabber
{

    // [ValueConversion(typeof(DateTime), typeof(bool))]
    public class DateConverter : IValueConverter
    {
        // checks whether a given Date (value) is more than or equal X days (parameter) away from today's date
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            string valueString = value.ToString();
            CultureInfo MyCultureInfo = new CultureInfo("de-DE");
            int i = 0;
            DateTime checkDate = DateTime.Parse(valueString, MyCultureInfo);
            DateTime curDate = DateTime.Now;
            /*
             *            
             *  curDate     checkDate     parameter   diff   return
             *              (from list)     (i)               
             *  ======================================================
             *  22.05.2019  21.05.2019      1         -1     false
             *  22.05.2019  22.05.2019      1          0     false
             *  22.05.2019  23.05.2019      1          1     true
             * 
             *  22.05.2019  21.05.2019      0         -1     false
             *  22.05.2019  22.05.2019      0          0     true
             *  22.05.2019  23.05.2019      0          1     true
             * 
             *  22.05.2019  21.05.2019      1         -1     false
             *  22.05.2019  22.05.2019      1          0     false
             *  22.05.2019  23.05.2019      1          1     true
             * 
             *  22.05.2019  21.05.2019      5         -1     false
             *  22.05.2019  22.05.2019      5          0     false
             *  22.05.2019  23.05.2019      5          1     false
             *  29.05.2019  23.05.2019      5         -6     true
             * 
             *  22.05.2019  21.05.2019      -5        -1     true
             *  22.05.2019  22.05.2019      -5         0     true
             *  22.05.2019  23.05.2019      -5         1     true
             *  29.05.2019  23.05.2019      -5        -6     false
             * 
             */
            // TimeSpan span = curDate.Subtract(checkDate);
            TimeSpan span = checkDate.Subtract(curDate);
            int diff = (int)span.Days;

            i = int.Parse(parameter.ToString());
            if (diff >= i)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
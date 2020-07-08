using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            var itemdata = value as Contacts;
            if (itemdata.ContactType == "HOME")
                return Color.RoyalBlue;
            else if (itemdata.ContactType == "WORK")
                return Color.PaleGreen;
            else if (itemdata.ContactType == "MOBILE")
                return Color.HotPink;
            else if (itemdata.ContactType == "OTHER")
                return Color.DarkGoldenrod;
           else
                return Color.BlueViolet;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

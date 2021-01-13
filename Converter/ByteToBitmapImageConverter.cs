using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CargoManagementSystem.Converter
{
    public class ByteToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage target = null;
            try
            {
                target = new BitmapImage();
                byte[] source = (byte[])value;
                target.BeginInit();
                target.StreamSource = new MemoryStream(source);
                target.EndInit();
            }
            catch
            {
                target = null;
            }
            return target;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

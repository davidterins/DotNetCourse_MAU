using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using GameCardLib;

namespace Assignment_2b.ViewModels.Converters
{
  public class ToColorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      LogColor color = (LogColor)value;

      SolidColorBrush brush = new SolidColorBrush();
      
      if(color == LogColor.Gray)
      {
        brush.Color = Colors.LightGray;
        return brush;
      }
      if (color == LogColor.Green)
      {
        brush.Color = Colors.Green;
        return brush;
      }
      if (color == LogColor.Yellow)
      {
        brush.Color = Colors.Yellow;
        return brush;
      }
      if (color == LogColor.Red)
      {
        brush.Color = Colors.Red;
        return brush;
      }
    
      return brush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}

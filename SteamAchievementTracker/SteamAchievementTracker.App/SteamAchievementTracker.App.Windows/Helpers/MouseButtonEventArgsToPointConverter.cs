using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace SteamAchievementTracker.App.Helpers
{
    public class MouseButtonEventArgsToPointConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            var args = (PointerRoutedEventArgs)value;
            var element = (FrameworkElement)parameter;

            var point = args.GetCurrentPoint(element);
            return new Point(point.Position.X, point.Position.Y);
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }
}

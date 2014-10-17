using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace SteamAchievementTracker.App.Helpers
{

    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double percent = System.Convert.ToDouble(value) / 100;
            return 250 * percent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

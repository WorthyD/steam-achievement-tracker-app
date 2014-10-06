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
                return System.Convert.ToDouble(parameter) *
                   System.Convert.ToDouble(value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
}

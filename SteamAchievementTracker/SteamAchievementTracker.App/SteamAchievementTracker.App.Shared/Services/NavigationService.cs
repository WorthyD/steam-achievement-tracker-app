using GalaSoft.MvvmLight.Ioc;
using SteamAchievementTracker.App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SteamAchievementTracker.App.Services
{
    public class NavigationService : INavigationService
    {
        public void GoBack()
        {
            var frame = ((Frame)Window.Current.Content);

            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public virtual void NavigateTo(string pageName)
        {
            switch (pageName)
            {
                case "Main":
                    var mainPageType = SimpleIoc.Default.GetInstance<Main>();
                    NavigateTo(mainPageType.GetType());
                    break;

                case "Details":
                    //var editPageType = SimpleIoc.Default.GetInstance<DetailsPage>();
                    NavigateTo(typeof(GameDetails));
                    break;
                default:
                    var defaultPageType = SimpleIoc.Default.GetInstance<Main>();
                    NavigateTo(defaultPageType.GetType());
                    break;
            }
        }

        public virtual void NavigateTo(Type sourcePageType)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType);
        }

        public void NavigateTo(Type sourcePageType, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }



        public void OpenBrowser(string url)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.Services
{
    public interface INavigationService
    {
        void GoBack();
        void Navigate(string pageName);
        void Navigate(Type pageType);
        void Navigate(Type sourcePageType, object parameter);

        void OpenBrowser(string url);
    }
}

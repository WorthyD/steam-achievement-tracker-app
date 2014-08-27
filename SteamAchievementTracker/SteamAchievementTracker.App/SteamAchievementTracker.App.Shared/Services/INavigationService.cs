using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.Services
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(string pageName);
        void NavigateTo(Type pageType);
        void NavigateTo(Type sourcePageType, object parameter);

        void OpenBrowser(string url);
    }
}

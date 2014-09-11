using SteamAchievementTracker.App.Common;
using SteamAchievementTracker.Contracts.Services;
//using SteamAchievementTracker.App.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.ViewModel
{
    public class GameDetailViewModel : BaseViewModel
    {
        public GameDetailViewModel(INavigationService _navigationService)
            : base(_navigationService)
        {
            //var navigationHelper = new NavigationHelper(this);
            //this.navigationHelper.LoadState += navigationHelper_LoadState;
            //this.navigationHelper.SaveState += navigationHelper_SaveState;

        }

    }
}

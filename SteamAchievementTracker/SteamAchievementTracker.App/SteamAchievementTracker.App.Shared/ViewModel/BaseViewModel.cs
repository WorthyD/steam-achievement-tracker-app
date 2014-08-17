using System;
using System.Collections.Generic;
using System.Text;

using GalaSoft.MvvmLight;

namespace SteamAchievementTracker.App.ViewModel {
    public class BaseViewModel :ViewModelBase {
        private readonly Common.NavigationHelper _navigationHelper;
        //public BaseViewModel(Common.NavigationHelper navHelper) {
        //    this._navigationHelper = navHelper;
        //}
        public string ConnectionString { get; set; }

        public BaseViewModel() {
            this.ConnectionString = "SteamAchievementTracker.db";
        }
    }
}

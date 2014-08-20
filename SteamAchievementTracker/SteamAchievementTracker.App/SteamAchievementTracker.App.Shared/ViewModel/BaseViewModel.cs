using System;
using System.Collections.Generic;
using System.Text;

using GalaSoft.MvvmLight;
using System.Diagnostics;

namespace SteamAchievementTracker.App.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        private readonly Common.NavigationHelper _navigationHelper;
        //public BaseViewModel(Common.NavigationHelper navHelper) {
        //    this._navigationHelper = navHelper;
        //}
        public string ConnectionString { get; set; }

        public BaseViewModel()
        {
            this.ConnectionString = "SteamAchievementTracker.db";
        }

        public long UserID
        {
            get
            {
                long tLong = 0;
                var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"];
                if (setting != null)
                {
                    long.TryParse(setting.ToString(), out tLong);
                    Debug.WriteLine("Retreiving UserID " + tLong);
                }
                return tLong;

            }
            set
            {

                Debug.WriteLine("Setting UserID " + value);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = value;
            }
        }
        public string UserName
        {
            get
            {
                string tUser = string.Empty;
                var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"];
                if (setting != null)
                {
                    Debug.WriteLine("Getting UserName" + ToString());
                    return setting.ToString();
                }
                return string.Empty;
            }
            set
            {
                Debug.WriteLine("Setting Name " + value);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = value;
            }
        }
    }
}

using GalaSoft.MvvmLight;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class BaseViewModel : ViewModelBase, IViewModel
    {
        public void Initialize(object parameter)
        {
            string.Format("");
        }

        private readonly INavigationService _navigationService;
        public BaseViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public string ConnectionString { get { return "SteamAchievementTracker.db"; } }


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

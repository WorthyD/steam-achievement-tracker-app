using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using SteamAchievementTracker.App.Views;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Windows.Storage;

#if WINDOWS_APP
using Windows.UI.ApplicationSettings;
#endif

namespace SteamAchievementTracker.App.ViewModel
{
    public class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        private string _UserName;
        public string UserName { get { return _UserName; } set { Set(() => UserName, ref _UserName, value); } }

        private long _UserID;
        public long UserID { get { return _UserID; } set { Set(() => UserID, ref _UserID, value); } }

        private bool _showNoAch;
        public bool ShowNoAch
        {
            get { return _showNoAch; }
            set
            {
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowNoAch"] = value;
                Set(() => ShowNoAch, ref _showNoAch, value);
            }
        }


        public RelayCommand LogOutUser { get; set; }
        public RelayCommand ClearCacheCommand { get; set; }

        private MainSettings sf { get; set; }

        private readonly INavigationService _navigationService;
        public SettingsViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.InitializeCommands();
        }

        public void Initialize()
        {

#if WINDOWS_APP
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
#endif
        }
        public void DeInitialize()
        {

#if WINDOWS_APP
            SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
#endif
        }
        public void InitializeCommands()
        {
            LogOutUser = new RelayCommand(() =>
            {
                LogOut();
            });
            ClearCacheCommand = new RelayCommand(() =>
            {
                ClearCache();
            });

        }

#if WINDOWS_APP
        void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs e)
        {
            SettingsCommand defaultsCommand = new SettingsCommand("settings", "Settings",
                (handler) =>
                {
                    ShowSettings();
                });
            e.Request.ApplicationCommands.Add(defaultsCommand);
        }
#endif
        public void ShowSettings()
        {
            if (sf == null) {
                sf = new MainSettings();
            }
            string tUser = string.Empty;
            var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"];
            if (setting != null)
            {
                UserName = setting.ToString();
            }

            long userId = 0;
            var userIdObj = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"];
            if (userIdObj != null)
            {
                long.TryParse(userIdObj.ToString(), out userId);
            }
            UserID = userId;

            bool showNoAch = false;
            var showNoAchObj = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowNoAch"];
            if (showNoAchObj != null)
            {
                bool.TryParse(showNoAchObj.ToString(), out showNoAch);
            }
            this.ShowNoAch = showNoAch;


            //Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"]
            sf.DataContext = this;

#if WINDOWS_APP
            sf.Show();
#endif



        }




        public void LogOut()
        {
            Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = 0;
            Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = string.Empty;
            Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowNoAch"] = false;

            var pageType = SimpleIoc.Default.GetInstance<IMain>();
            _navigationService.Navigate(pageType.GetType(), null);
        }

        public async void ClearCache()
        {

            string DBName = "SteamAchievementTracker.db";
            DataAccess.Data.PlayerProfile pp = new DataAccess.Data.PlayerProfile(DBName);
            pp.DestroySQLDatabase();

            var pageType = SimpleIoc.Default.GetInstance<IMain>();
            _navigationService.Navigate(pageType.GetType(), null);

        }
    }
}

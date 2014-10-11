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
using Windows.UI.ApplicationSettings;

namespace SteamAchievementTracker.App.ViewModel
{
    public class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        private string _UserName;
        public string UserName { get { return _UserName; } set { Set(() => UserName, ref _UserName, value); } }

        private long _UserID;
        public long UserID { get { return _UserID; } set { Set(() => UserID, ref _UserID, value); } }

        public RelayCommand LogOutUser { get; set; }
        public RelayCommand ClearCacheCommand { get; set; }



        private readonly INavigationService _navigationService;
        public SettingsViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.InitializeCommands();
        }

        public void Initialize()
        {
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
        }
        public void DeInitialize()
        {

            SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
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

        void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs e)
        {
            SettingsCommand defaultsCommand = new SettingsCommand("defaults", "Defaults",
                (handler) =>
                {
                    // SettingsFlyout1 is defined in "SettingsFlyout1.xaml"
                    //rootPage.NotifyUser("You opened the 'Defaults' SettingsFlyout.", NotifyType.StatusMessage);
                    //SettingsFlyout1 sf = new SettingsFlyout1();
                    ShowSettings();
                });
            e.Request.ApplicationCommands.Add(defaultsCommand);
        }

        public void ShowSettings()
        {
            MainSettings sf = new MainSettings();
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


            //Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"]
            sf.DataContext = this;
            sf.Show();



        }




        public void LogOut()
        {
            Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = 0;
            Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = string.Empty;

            var pageType = SimpleIoc.Default.GetInstance<IMain>();
            _navigationService.Navigate(pageType.GetType(), null);
        }

        public async void ClearCache()
        {

             string DBName = "SteamAchievementTracker.db";
            DataAccess.Data.PlayerProfile pp = new DataAccess.Data.PlayerProfile(DBName);
            pp.DestroySQLDatabase();
            //try
            //{
            //    await Windows.Storage.ApplicationData.Current.ClearAsync();
            //}
            //catch (Exception)
            //{
            //    Debug.WriteLine("Clearing Cache Failed");
            //}
            //StorageFile filed = await ApplicationData.Current.LocalFolder.GetFileAsync(DBName);
            //if (filed != null)
            //{
            //    await filed.DeleteAsync();

            //}

            var pageType = SimpleIoc.Default.GetInstance<IMain>();
            _navigationService.Navigate(pageType.GetType(), null);
 
        }
    }
}

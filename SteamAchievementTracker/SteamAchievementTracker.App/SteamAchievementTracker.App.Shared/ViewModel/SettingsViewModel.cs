using GalaSoft.MvvmLight;
using SteamAchievementTracker.App.Views;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.ApplicationSettings;

namespace SteamAchievementTracker.App.ViewModel
{
    public class SettingsViewModel : ViewModelBase, ISettingsViewModel
    {
        private string _UserName;
        public string UserName { get { return _UserName; } set { Set(() => UserName, ref _UserName, value); } }



        public void Initialize()
        {
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
        }
        public void DeInitialize()
        {

            SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
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
                    UserName = setting;
                }
            //Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"]
            sf.Show();
        }


    }
}

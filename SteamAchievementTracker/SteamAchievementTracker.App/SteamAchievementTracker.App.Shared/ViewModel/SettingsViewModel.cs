using SteamAchievementTracker.App.Views;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.ApplicationSettings;

namespace SteamAchievementTracker.App.ViewModel
{
    public class SettingsViewModel : ISettingsViewModel
    {
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
                    MainSettings sf = new MainSettings();
                    sf.Show();
                });
            e.Request.ApplicationCommands.Add(defaultsCommand);

        }


    }
}

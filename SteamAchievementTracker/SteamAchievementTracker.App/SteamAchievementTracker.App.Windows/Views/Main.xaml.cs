using SteamAchievementTracker.App.Common;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SteamAchievementTracker.App.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : LayoutAwarePage, IView
    {
        public Main() {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
        }

        IViewModel IView.ViewModel
        {
            get { return this.DataContext as IViewModel; }
        }

        private void Hub_SectionHeaderClick(object sender, HubSectionHeaderClickEventArgs e)
        {
            SteamAchievementTracker.ViewModel.MainViewModel model = this.DataContext as SteamAchievementTracker.ViewModel.MainViewModel;
            model.OpenLibrary();
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

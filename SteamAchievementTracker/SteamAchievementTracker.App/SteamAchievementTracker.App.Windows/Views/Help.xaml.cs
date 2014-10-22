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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SteamAchievementTracker.App.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Help : Page, IHelp
    {
        public Help()
        {
            this.InitializeComponent();
        }
        IViewModel IView.ViewModel
        {
            get { return this.DataContext as IHelpViewModel; }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //DependencyObject c = VisualTreeHelper.GetChild(HelperGridTemplate, 0);

            //var x = HelperGrid.FindName("HelpVideo") as WebView;
            //var x = HelperGrid.f as WebView;
            //x.NavigateToString(model.VideoContent);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SteamAchievementTracker.ViewModel.HelpViewModel model = this.DataContext as SteamAchievementTracker.ViewModel.HelpViewModel;
            WebView  wv = (WebView)sender;
            wv.NavigateToString( model.VideoContent);
        }

    }

}

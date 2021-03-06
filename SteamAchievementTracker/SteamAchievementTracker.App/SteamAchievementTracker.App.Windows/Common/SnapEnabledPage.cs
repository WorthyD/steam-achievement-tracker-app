using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SteamAchievementTracker.App.Common
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public class SnapEnabledPage
         : Page
    {
        //public BasicPage()
        //{
        //    this.Loaded += page_Loaded;
        //    this.Unloaded += page_Unloaded;
        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var navigableViewModel = this.DataContext as IViewModel;
            if (navigableViewModel != null)
                navigableViewModel.Load(e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var navigableViewModel = this.DataContext as IViewModel;
            if (navigableViewModel != null)
                navigableViewModel.UnLoad(e.Parameter);
        }

        public SnapEnabledPage()
        {
            //    this.Loaded += page_Loaded;
            //   this.Unloaded += page_Unloaded;
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += Window_SizeChanged;
            DetermineVisualState();
        }

        private void page_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            DetermineVisualState();
        }

        private void DetermineVisualState()
        {
            var state = string.Empty;
            var applicationView = ApplicationView.GetForCurrentView();
            var size = Window.Current.Bounds;

            if (applicationView.IsFullScreen)
            {
                if (applicationView.Orientation == ApplicationViewOrientation.Landscape)
                    state = "FullScreenLandscape";
                else
                    state = "FullScreenPortrait";
            }
            else
            {
                if (size.Width == 320)
                    state = "Snapped";
                else if (size.Width <= 700)
                    state = "Narrow";
                else
                    state = "Filled";
            }

            System.Diagnostics.Debug.WriteLine("Width: {0}, New VisulState: {1}",
                size.Width, state);

            VisualStateManager.GoToState(this, state, true);
        }

    }
}

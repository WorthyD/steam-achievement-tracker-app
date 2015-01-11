using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SteamAchievementTracker.Services.Infrastructure {
    public class NavigationService : INavigationService {

        private Frame frame;
        public Frame Frame {
            get {
                return frame;
            }
            set {
                frame = value;
                frame.Navigated += OnFrameNavigated;
                frame.Unloaded += frame_Unloaded;
            }
        }

        public void GoBack() {
            //var frame = ((Frame)Window.Current.Content);

            if (Frame.CanGoBack) {
                Frame.GoBack();
            }
        }
        public bool CanGoBack() {
            return Frame.CanGoBack;
        }

        public virtual void Navigate(string pageName) {
            //switch (pageName)
            //{
            //    case "Main":
            //        var mainPageType = SimpleIoc.Default.GetInstance<Main>();
            //        NavigateTo(mainPageType.GetType());
            //        break;

            //    case "Details":
            //        //var editPageType = SimpleIoc.Default.GetInstance<DetailsPage>();
            //        NavigateTo(typeof(GameDetails));
            //        break;
            //    default:
            //        var defaultPageType = SimpleIoc.Default.GetInstance<Main>();
            //        NavigateTo(defaultPageType.GetType());
            //        break;
            //}
        }
        public NavigationService() {
            //  ((Frame)Window.Current.Content).Navigated += OnFrameNavigated;


        }

        public virtual void Navigate(Type sourcePageType) {
            Frame.Navigate(sourcePageType);
        }

        public void Navigate(Type sourcePageType, object parameter) {
            Frame.Navigate(sourcePageType, parameter);
        }



        public void OpenBrowser(string url) {
            throw new NotImplementedException();
        }
        private void frame_Unloaded(object sender, RoutedEventArgs e) {
//#if WINDOWS_PHONE_APP
//            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
//#endif
        }
        public virtual void OnFrameNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e) {
//#if WINDOWS_PHONE_APP
//            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
//#endif
            var view = e.Content as IView;
            if (view == null)
                return;

            var viewModel = view.ViewModel;
            if (viewModel != null) {
                if (!(e.NavigationMode ==
                    Windows.UI.Xaml.Navigation.NavigationMode.Back
                    &&
                    (((Page)e.Content).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled ||
                    (((Page)e.Content).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Required)))) {
                    viewModel.Initialize(e.Parameter);
                }
            }
        }

        public void Navigate(string type, object parameter) {
            throw new NotImplementedException();
        }
        //#if WINDOWS_PHONE_APP
        ///// <summary>
        ///// Invoked when the hardware back button is pressed. For Windows Phone only.
        ///// </summary>
        ///// <param name="sender">Instance that triggered the event.</param>
        ///// <param name="e">Event data describing the conditions that led to the event.</param>
        //private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        //{
        //   this.GoBack()
        //}
        //#endif
    }
}

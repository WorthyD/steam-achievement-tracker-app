using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SteamAchievementTracker.Services.Infrastructure
{
    public class NavigationService : INavigationService
    {
        private Frame frame;
        public Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                frame.Navigated += OnFrameNavigated;
            }
        }

        public NavigationService()
        {

        }

        public void Navigate(Type type)
        {
            Frame.Navigate(type);
        }

        public void Navigate(Type type, object parameter)
        {
            Frame.Navigate(type, parameter);
        }

        public void Navigate(string type, object parameter)
        {
            //switch (type)
            //{
            //    case PageNames.PopularTravelView:
            //        Navigate<IPopularTravelView>(parameter); break;
            //    case PageNames.TravelDetailView:
            //        Navigate<ITravelDetailView>(parameter); break;
            //    case PageNames.ContinentDetailView:
            //        Navigate<IContinentDetailView>(parameter); break;
            //    case PageNames.InfiniteTravelView:
            //        Navigate<IInfiniteTravelView>(parameter); break;
            //}
        }

        //private void Navigate<T>(object parameter) where T : IView
        //{
        //    DisposePreviousView();
        //    var viewType = InstanceFactory.Registrations.ContainsKey(typeof(T)) ? InstanceFactory.Registrations[typeof(T)] : typeof(T);
        //    Frame.Navigate(viewType, parameter);
        //}

        public IView CurrentView
        {
            get { return frame.Content as IView; }
        }

        private void DisposePreviousView()
        {
            try
            {
                if (this.CurrentView != null && ((Page)this.CurrentView).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled)
                {
                    var currentView = this.CurrentView;
                    var currentViewDisposable = currentView as IDisposable;

                    // if(currentView is BasePage
                    if (currentViewDisposable != null)
                    {
                        currentViewDisposable.Dispose();
                        currentViewDisposable = null;
                    } //view model is disposed in the view implementation
                    currentView = null;
                    GC.Collect();
                }
            }
            catch { }
        }

        public void Navigate(string type)
        {
            Frame.Navigate(Type.GetType(type));
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnFrameNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var view = e.Content as IView;
            if (view == null)
                return;

            var viewModel = view.ViewModel;
            if (viewModel != null)
            {
                if (!(e.NavigationMode ==
                    Windows.UI.Xaml.Navigation.NavigationMode.Back
                    &&
                    (((Page)e.Content).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled ||
                    (((Page)e.Content).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Required))))
                {
                    viewModel.Initialize(e.Parameter);
                }
            }
        }
    }
}

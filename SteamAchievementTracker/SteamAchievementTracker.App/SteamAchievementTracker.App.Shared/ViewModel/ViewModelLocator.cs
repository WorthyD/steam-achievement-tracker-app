using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SteamAchievementTracker.App.Services;

namespace SteamAchievementTracker.App.ViewModel {
    public class ViewModelLocator {

        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public GameDetailViewModel GameDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameDetailViewModel>();
            }
        }

        static ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GameDetailViewModel>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

        }
    }
}

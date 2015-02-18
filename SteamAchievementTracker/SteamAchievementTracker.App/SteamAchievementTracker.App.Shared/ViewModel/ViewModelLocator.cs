using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
//using SteamAchievementTracker.App.Services;
using SteamAchievementTracker.ViewModel;
using SteamAchievementTracker.Contracts.ViewModels;
using GalaSoft.MvvmLight;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Services.Infrastructure;
using SteamAchievementTracker.Services.Data;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.App.Views;

namespace SteamAchievementTracker.App.ViewModel {
    public class ViewModelLocator {

        public MainViewModel Main {
            get {

                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public BaseViewModel Base {
            get {
                return ServiceLocator.Current.GetInstance<BaseViewModel>();
            }
        }

        public GameDetailsViewModel GameDetails {
            get {
                return ServiceLocator.Current.GetInstance<GameDetailsViewModel>();
            }
        }

        public GameLibraryViewModel GameLibrary {
            get {
                return ServiceLocator.Current.GetInstance<GameLibraryViewModel>();
            }
        }

        public HelpViewModel Help {
            get {
                return ServiceLocator.Current.GetInstance<HelpViewModel>();
            }
        }

        public SettingsViewModel MainSettings {
            get {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }


        static ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic) {
                SimpleIoc.Default.Register<IPlayerLibraryService, DesignData.Services.PlayerLibraryService>();
                SimpleIoc.Default.Register<IPlayerProfileService, DesignData.Services.PlayerProfileService>();
                SimpleIoc.Default.Register<IPlayerStatsService, DesignData.Services.PlayerStatsService>();
            } else {
                SimpleIoc.Default.Register<IPlayerLibraryService, PlayerLibraryService>();
                SimpleIoc.Default.Register<IPlayerProfileService, PlayerProfileService>();
                SimpleIoc.Default.Register<IPlayerStatsService, PlayerStatsService>();

            }
            SimpleIoc.Default.Register<IGameDetailsView, GameDetails>();
            SimpleIoc.Default.Register<IGameLibrary, GameLibrary>();
            SimpleIoc.Default.Register<IMain, Main>();
            SimpleIoc.Default.Register<IMainSettings, MainSettings>();
            //SimpleIoc.Default.Register<IHelp, Help>();
#if WINDOWS_PHONE_APP
            SimpleIoc.Default.Register<INavigationService, SteamAchievementTracker.App.Services.NavigationService>();
#else

            SimpleIoc.Default.Register<INavigationService, NavigationService>();
#endif

            SimpleIoc.Default.Register<ISettingsViewModel, SettingsViewModel>();

            SimpleIoc.Default.Register<ITrackingService, Services.TrackingService>();

            SimpleIoc.Default.Register<BaseViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GameDetailsViewModel>();
            SimpleIoc.Default.Register<GameLibraryViewModel>();
            SimpleIoc.Default.Register<HelpViewModel>();
        }
    }
}

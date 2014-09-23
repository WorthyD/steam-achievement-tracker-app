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

namespace SteamAchievementTracker.App.ViewModel
{
    public class ViewModelLocator
    {

        public MainViewModel Main
        {
            get
            {

                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public GameDetailsViewModel GameDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GameDetailsViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IPlayerLibraryService, DesignData.Services.PlayerLibraryService>();
                SimpleIoc.Default.Register<IPlayerProfileService, DesignData.Services.PlayerProfileService>();
                SimpleIoc.Default.Register<IPlayerStatsService, DesignData.Services.PlayerStatsService>();
             }
            else
            {
                SimpleIoc.Default.Register<IPlayerLibraryService, PlayerLibraryService>();
                SimpleIoc.Default.Register<IPlayerProfileService, PlayerProfileService>();
                SimpleIoc.Default.Register<IPlayerStatsService, PlayerStatsService>();

            }
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GameDetailsViewModel>();
        }
    }
}

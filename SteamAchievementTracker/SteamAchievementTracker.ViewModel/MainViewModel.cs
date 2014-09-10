﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;
using SteamAchievementTracker.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {

        private IPlayerProfileService playerProfService;
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;

        public MainViewModel()
        {


            //this.navigationService = _navigationService;
            //this.playerLibService = _playerLibService;
            //this.playerProfService = _playerProfService;

            //if(base.IsInDesignMode){
            //    this.Initialize(null);
            //}
        }




        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                Set(() => Title, ref _title, value);
            }
        }

        private IProfile _profile;

        public IProfile Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                Set(() => Profile, ref _profile, value);
            }
        }

        private IPlayerLibrary _library;
        public IPlayerLibrary Library
        {
            get { return _library; }
            set
            {
                Set(() => Library, ref _library, value);
            }
        }

        public RelayCommand<IGame> OpenGame
        {
            get;
            set;
        }

        private void InitializeCommands()
        {
            OpenGame = new RelayCommand<IGame>(game =>
                    {


                    });
        }

        public async void Initialize(object parameter)
        {
            //_profile = new IProfile();
            //_library = new DataAccess.Model.PlayerLibrary();

            //_title = "Steam Achievement Tracker";
            //var result = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            //if (base.UserID == 0)
            //{
            //    //Return login
            //    base.UserID = 76561198025095151;
            //    base.UserName = "WorthyD";
            //}

            //Profile = await playerProfService.GetProfileCached(base.UserID, base.UserName);
            //var gameList = await playerLibService.GetPlayerRecentlyPlayedGames(base.UserID, base.UserName);
            
            //Library = new  PlayerLibrary()
            //{
            //    GameList = gameList.OrderByDescending(x => x.RecentHours).ToList()
            //};

        }
    }
}

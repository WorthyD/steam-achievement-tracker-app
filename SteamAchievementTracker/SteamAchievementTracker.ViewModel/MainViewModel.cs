using GalaSoft.MvvmLight.Command;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        //private DataAccess.Repository.PlayerProfileRepository _playerRepo;

        private IPlayerProfileService playerProfService;
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;

        //private DataAccess.Repository.PlayerLibraryRepository _libraryRepo;

        public MainViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService)
            : base(_navigationService)
        {


            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;

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
        //private RelayCommand<IGame> _openGame;

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

            _title = "Steam Achievement Tracker";
            var result = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            Debug.WriteLine(result);

            if (base.UserID == 0)
            {
                //Return login
                base.UserID = 76561198025095151;
                base.UserName = "WorthyD";
            }

            Profile = await playerProfService.GetProfileCached(base.UserID, base.UserName);
            //Library = null;
            //Library.GameList = await playerLibService.GetPlayerRecentlyPlayedGames(base.UserID, base.UserName);

            //Todo: udpate
            //Library = new IPlayerLibrary()
            //{
            //    GameList = gameList.OrderByDescending(x => x.RecentHours).ToList()
            //};

        }
    }
}

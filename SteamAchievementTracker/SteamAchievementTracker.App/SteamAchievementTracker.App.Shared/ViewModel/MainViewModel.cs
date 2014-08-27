using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Windows.UI.Xaml.Shapes;
using System.Diagnostics;
using SteamAchievementTracker.App.Services;
using GalaSoft.MvvmLight.Command;
using SteamAchievementTracker.App.DataAccess.Model;

namespace SteamAchievementTracker.App.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //public MainViewModel(Common.NavigationHelper navigationService)
        //    : base(navigationService) {
        //    HelloWorld = IsInDesignMode
        //       ? "Runs in design mode"
        //       : "Runs in runtime mode";

        //}
        private DataAccess.Repository.PlayerProfileRepository _playerRepo;

        private DataAccess.Repository.PlayerLibraryRepository _libraryRepo;

        //[PreferredConstructor]
        public MainViewModel(INavigationService _navigationService)
            : base(_navigationService)
        {
            _playerRepo = new DataAccess.Repository.PlayerProfileRepository(base.ConnectionString);
            _libraryRepo = new DataAccess.Repository.PlayerLibraryRepository(base.ConnectionString);


            _profile = new DataAccess.Model.Profile();
            _library = new DataAccess.Model.PlayerLibrary();

            _title = "Steam Achievement Tracker";
            var result = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            Debug.WriteLine(result);

            if (IsInDesignMode)
            {
                _profile.PopulateDesignData();
                _library.PopulateDesignData();
                return;
            }

            if (base.UserID == 0)
            {
                //Return login
                base.UserID = 76561198025095151;
                base.UserName = "WorthyD";
            }

            LoadRealData();
        }
        public async void LoadRealData()
        {
            Profile = await _playerRepo.GetProfileCached(base.UserID, base.UserName);
            List<DataAccess.Model.Game> gameList = await _libraryRepo.GetPlayerRecentlyPlayedGames(base.UserID, base.UserName);

            Library = new DataAccess.Model.PlayerLibrary()
            {
                GameList = gameList.OrderByDescending(x => x.RecentHours).ToList()
            };
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

        private DataAccess.Model.Profile _profile;

        public DataAccess.Model.Profile Profile
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

        private DataAccess.Model.PlayerLibrary _library;
        public DataAccess.Model.PlayerLibrary Library
        {
            get { return _library; }
            set
            {
                Set(() => Library, ref _library, value);
            }
        }
        private RelayCommand<Game> _openGame;
        
        public RelayCommand<Game> OpenGame
        {
            get
            {
                return _openGame ?? (_openGame = new RelayCommand<Game>(game => { 
                
                
                }));
            }
        }

    }
}

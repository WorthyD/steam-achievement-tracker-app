using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
using Windows.UI.Xaml.Controls;

namespace SteamAchievementTracker.ViewModel
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {

        private IPlayerProfileService playerProfService;
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;
        public MainViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService, IPlayerProfileService _playerProfService)
            : base(_navigationService)
        {


            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;
            this.playerProfService = _playerProfService;

            if (base.IsInDesignMode)
            {
                this.Initialize(null);
            }
            this.InitializeCommands();
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
        private string _libCount;
        public string LibCount
        {
            get { return _libCount; }
            set
            {
                Set(() => LibCount, ref _libCount, value);
            }
        }

        //public RelayCommand<IGame> OpenGame
        public RelayCommand<ItemClickEventArgs> OpenGame
        {
            get;
            set;
        }

        private void InitializeCommands()
        {

            Debug.WriteLine("Init Commands");
            OpenGame = new RelayCommand<ItemClickEventArgs>(game =>
                    {
                        var x = (IGame)game.ClickedItem;
                        var pageType = SimpleIoc.Default.GetInstance<IGameDetailsView>();
                       navigationService.Navigate(pageType.GetType(), x.AppID);
                        Debug.WriteLine("Click - " + x.AppID);
                    });
        }

        public async void Initialize(object parameter)
        {
            _title = "Steam Achievement Tracker";

            if (base.UserID == 0)
            {
                //Return login
                base.UserID = 76561198025095151;
                base.UserName = "WorthyD";
            }

            Profile = playerProfService.GetProfileFromDB(base.UserID);

            if ((Profile == null) || Profile.LastUpdate < DateTime.Now.AddMinutes(-Settings.Profile.ProfileRefreshInterval))
            {
                Profile = await playerProfService.GetFreshPlayerDetails(base.UserName, (Profile != null));
                //TODO: Update library
                var tempGames = playerLibService.GetPlayerLibraryRefresh(base.UserID, base.UserName);
            }



            if (Profile.RecentGameLinks != null && Profile.RecentGameLinks.Count > 0)
            {
                var gameList = playerLibService.GetPlayerRecentlyPlayedGames(base.UserID, Profile.RecentGameLinks);
                Library = new PlayerLibrary()
                {
                    GameList = gameList.ToList()
                };
            }


            //TODO: Get Stats
            ///LibCount = Library.GameList.Count().ToString();

        }
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
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
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SteamAchievementTracker.ViewModel
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {

        #region Services
        private IPlayerProfileService playerProfService;
        private IPlayerLibraryService playerLibService;
        private IPlayerStatsService playerStatsService;
        private INavigationService navigationService;
        #endregion

        #region Commands
        public RelayCommand<ItemClickEventArgs> OpenGame
        {
            get;
            set;
        }
        //public RelayCommand<ItemClickEventArgs> OpenLibrary
        //{
        //    get;
        //    set;
        //}


        #endregion

        #region Properties
        public ViewModel.LoginViewModel LoginVM { get; set; }
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

        //private IPlayerLibrary _library;
        //public IPlayerLibrary Library
        //{
        //    get { return _library; }
        //    set
        //    {
        //        Set(() => Library, ref _library, value);
        //    }
        //}

        private List<IGame> _gameList;
        public List<IGame> GameList { get { return _gameList; } set { Set(() => GameList, ref _gameList, value); } }

        private List<IGame> _mostPlayedGames;
        public List<IGame> MostPlayedGames { get { return _mostPlayedGames; } set { Set(() => MostPlayedGames, ref _mostPlayedGames, value); } }

        private List<IGame> _NearComp;
        public List<IGame> NearCompletion { get { return _NearComp; } set { Set(() => NearCompletion, ref _NearComp, value); } }


 
        private IStatistics _playerStats;
        public IStatistics PlayerStats
        {
            get { return _playerStats; }
            set
            {
                Set(() => PlayerStats, ref _playerStats, value);
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

        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { Set(() => IsLoading, ref _IsLoading, value); } }
     
        #endregion

        public MainViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService, IPlayerProfileService _playerProfService, IPlayerStatsService _playerStatsService)
            : base(_navigationService)
        {


            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;
            this.playerProfService = _playerProfService;
            this.playerStatsService = _playerStatsService;

            this.InitializeCommands();
            LoginVM = new LoginViewModel();
            LoginVM.playerLibService = _playerLibService;
            LoginVM.playerProfService = _playerProfService;
            LoginVM.InitializeCommands();
             if (base.IsInDesignMode)
            {
                this.Initialize(null);
                this.IsLoggedIn = true;
            }
       }




        //public RelayCommand<IGame> OpenGame
        private void InitializeCommands()
        {
            OpenGame = new RelayCommand<ItemClickEventArgs>(game =>
                    {

                        this.DeInitialize();
                        var x = (IGame)game.ClickedItem;
                        var pageType = SimpleIoc.Default.GetInstance<IGameDetailsView>();
                        navigationService.Navigate(pageType.GetType(), x.AppID);
                    });
        }
        public void OpenLibrary()
        {
            this.DeInitialize();
            var pageType = SimpleIoc.Default.GetInstance<IGameLibrary>();
            navigationService.Navigate(pageType.GetType(), null);
        }

        public override void Initialize(object parameter)
        {
            base.Initialize(parameter);

            _title = "Steam Achievement Tracker";

            if (base.UserID != 0 || base.IsInDesignMode)
            {
                this.LoadData();
                this.IsLoggedIn = true;
                this.LoginVM.IsVisible = false;
            }
            else
            {


                Messenger.Default.Register<string>(this,
                    message =>
                    {
                        if (message == "LoggedIn")
                        {
                            this.LoadData();
                            this.LoginVM.IsVisible = false;
                            Messenger.Default.Unregister<string>(this);
                        }
                    });

                this.IsLoggedIn = false;
                this.EmptyData();
                this.LoginVM.IsVisible = true;
            }
            base.TrackEvent("Navigation", "Loaded", "HomeScreen");
        }

        public async void LoadData()
        {
            this.IsLoading = true;
            Profile = playerProfService.GetProfileFromDB(base.UserID);
            List<IGame> AllGames = new List<IGame>();
            List<IGame> RecentGames = new List<IGame>();
            List<IGame> nearCompletion = new List<IGame>();
            List<IGame> mostPlayedGames = new List<IGame>();

            if (base.HasNetwork() && (Profile == null || Profile.LastUpdate < DateTime.Now.AddMinutes(-Settings.Profile.ProfileRefreshInterval)))
            {
                Profile = await playerProfService.GetFreshPlayerDetails(base.UserName, (Profile != null));
                AllGames = await playerLibService.GetPlayerLibraryRefresh(base.UserID, base.UserName);
            }
            else
            {
                AllGames = await playerLibService.GetPlayerLibraryCached(base.UserID);
            }

            this.PlayerStats = playerLibService.GetPlayerStats(base.UserID);


            if (AllGames != null && AllGames.Count() > 0)
            {
                mostPlayedGames = AllGames.OrderByDescending(x => x.HoursPlayed).Take(6).ToList();
                nearCompletion = AllGames.Where(x => x.PercentComplete < 100).OrderByDescending(x => x.PercentComplete).Take(6).ToList();
            }



            if (Profile.RecentGameLinks != null && Profile.RecentGameLinks.Count > 0)
            {
                RecentGames = playerLibService.GetPlayerRecentlyPlayedGames(base.UserID, Profile.RecentGameLinks);
            }

            this.GameList = RecentGames;
            this.NearCompletion = nearCompletion;
            this.MostPlayedGames = mostPlayedGames;



            //Library = new PlayerLibrary()
            //{
            //    GameList = RecentGames,
            //    MostPlayedGames = MostPlayedGames,
            //    NearCompletion = NearCompletion
            //};


            if (base.HasNetwork())
            {
                RefreshRecentGames();
            }
            this.IsLoading = false;
        }
        public async void EmptyData()
        {
            //Library = new PlayerLibrary();
            GameList = new List<IGame>();
            NearCompletion = new List<IGame>();
            MostPlayedGames = new List<IGame>();
            Profile = new Profile();
        }

        public async void RefreshRecentGames()
        {
            var progressIndicator = new Progress<int>(ReportProgress);
            var cancelLibrary = new CancellationTokenSource();
            await playerStatsService.UpdateStatsByList(GameList, progressIndicator, cancelLibrary.Token);
            var gameList = playerLibService.GetPlayerRecentlyPlayedGames(base.UserID, Profile.RecentGameLinks);

            bool refresh = false;
            foreach (var g in gameList)
            {
                var tg = GameList.Where(x => x.AppID == g.AppID).FirstOrDefault();
                if (tg != null && g.AchievementsEarned != tg.AchievementsEarned)
                {
                    refresh = true;
                }

            }

            if (refresh)
            {
                GameList = gameList.ToList();
                //var temp = this.Library;
                //Library = new PlayerLibrary()
                //{
                //    GameList = gameList.ToList(),
                //    MostPlayedGames = temp.MostPlayedGames,
                //    NearCompletion = temp.NearCompletion
                //};
            }

        }

        public void ReportProgress(int value)
        {

        }
    }
}

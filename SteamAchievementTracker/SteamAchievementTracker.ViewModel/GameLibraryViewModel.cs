using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;
using SteamAchievementTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SteamAchievementTracker.ViewModel {
    public class GameLibraryViewModel : BaseViewModel, IGameLibraryViewModel {
        //Services
        #region Services
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;
        private IPlayerStatsService playerStatsService;
        #endregion

        #region Properties

        private int RefreshCount = 0;

        private List<IGame> _gameList;
        public List<IGame> GameList {
            get { return _gameList; }
            set {
                Set(() => GameList, ref _gameList, value);
            }
        }
        //private List<object> _gameListchar;
        //public List<object> GameListChar
        //{
        //    get { return _gameListchar; }
        //    set
        //    {
        //        Set(() => GameListChar, ref _gameListchar, value);
        //    }
        //}
        private string _libProgress;
        public string LibProgress {
            get {
                return _libProgress;
            }
            set {
                Set(() => LibProgress, ref _libProgress, value);
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing {
            get {
                return _isRefreshing;
            }
            set {
                Set(() => IsRefreshing, ref _isRefreshing, value);
            }
        }

        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { Set(() => IsLoading, ref _IsLoading, value); } }



        private const string titleAsc = "Title - Asc";
        private const string titleDsc = "Title - Desc";
        private const string playTimeAsc = "Playtime - Asc";
        private const string playTimeDsc = "Playtime - Desc";
        private const string progressAsc = "Progress - Asc";
        private const string progressDsc = "Progress - Desc";
        private const string achCountAsc = "Achievement Count - Asc";
        private const string achCountDesc = "Achievement Count - Desc";

        private CancellationTokenSource cancelLibrary;

        public ObservableCollection<string> SortLib {
            get {
                return new ObservableCollection<string>() { 
                    titleAsc,
                    titleDsc,
                    playTimeAsc,
                    playTimeDsc,
                    progressAsc,
                    progressDsc,
                    achCountAsc,
                    achCountDesc
            };
            }
        }

        private string _mySelectedItem;
        public string SelectedSort {
            get { return _mySelectedItem; }
            set {
                if (_mySelectedItem != value) {

                    Debug.WriteLine("UpdatingSelected Item");
                    Set(() => SelectedSort, ref _mySelectedItem, value);

                    Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"] = value;
                    if (GameList != null) {
                        GameList = ApplySort(GameList);
                    }
                }
            }
        }

        private bool _showNoAch;
        public bool ShowNoAch {
            get {
                if (_showNoAch == null) {
                    bool showNoAch = true;
                    var showNoAchObj = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowNoAch"];
                    if (showNoAchObj != null) {
                        bool.TryParse(showNoAchObj.ToString(), out showNoAch);
                    }
                    _showNoAch = showNoAch;
                }
                return _showNoAch;
            }
            set {
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowNoAch"] = value;
                Set(() => ShowNoAch, ref _showNoAch, value);
                 GetGames();
            }
        }
        private bool _ShowOneEarned;
        public bool ShowOneEarned {
            get {
                if (_showNoAch == null) {
                    bool showNoAch = false;
                    var ShowOneEarnedObj = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowOneEarned"];
                    if (ShowOneEarnedObj != null) {
                        bool.TryParse(ShowOneEarnedObj.ToString(), out showNoAch);
                    }
                    _ShowOneEarned = showNoAch;
                }
                return _ShowOneEarned;
            }
            set {
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ShowOneEarned"] = value;
                Set(() => ShowOneEarned, ref _ShowOneEarned, value);
                 GetGames();
            }
        }
        //ShowOneEarned

        #endregion

        #region Events
        //Events 
        public RelayCommand<ItemClickEventArgs> OpenGame { get; set; }
        public RelayCommand StartRefresh { get; set; }
        public RelayCommand CancelRefresh { get; set; }
        #endregion






        public GameLibraryViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService, IPlayerStatsService _playerStatsService)
            : base(_navigationService) {
            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;
            this.playerStatsService = _playerStatsService;

            if (base.IsInDesignMode) {
                this.Initialize(null);
                this.LibProgress = "Updating: {0} out of {1}";
            }
            if (Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"] != null) {
                SelectedSort = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"].ToString();
            } else {
                SelectedSort = titleAsc;
            }

            this.InitializeCommands();
        }
        private List<IGame> ApplySort(List<IGame> list) {
            if (list == null) return null;

            string sort = titleAsc;

            if (Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"] != null) {
                sort = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"].ToString();
            }


            switch (sort) {
                case titleAsc:
                    list = list.OrderBy(x => x.Name).ToList();
                    break;
                case titleDsc:
                    list = list.OrderByDescending(x => x.Name).ToList();
                    break;
                case playTimeAsc:
                    list = list.OrderBy(x => x.HoursPlayed).ToList();
                    break;
                case playTimeDsc:
                    list = list.OrderByDescending(x => x.HoursPlayed).ToList();
                    break;
                case progressAsc:
                    list = list.OrderBy(x => x.PercentComplete).ToList();
                    break;
                case progressDsc:
                    list = list.OrderByDescending(x => x.PercentComplete).ToList();
                    break;
                case achCountAsc:
                    list = list.OrderBy(x => x.TotalAchievements).ToList();
                    break;
                case achCountDesc:
                    list = list.OrderByDescending(x => x.TotalAchievements).ToList();
                    break;


            }
            return list;
        }


        private void InitializeCommands() {
            OpenGame = new RelayCommand<ItemClickEventArgs>(game => {
                this.DeInitialize();
                var x = (IGame)game.ClickedItem;
                var pageType = SimpleIoc.Default.GetInstance<IGameDetailsView>();
                navigationService.Navigate(pageType.GetType(), x.AppID);
                Debug.WriteLine("Click - " + x.AppID);
            });
            StartRefresh = new RelayCommand(() => {
                StartLibraryRefresh();
            });
            CancelRefresh = new RelayCommand(() => {
                Debug.WriteLine("Stop Relay");
                StopLibraryRefresh();
            });
        }
        public async override void Initialize(object parameter) {
            base.Initialize(parameter);

            await GetGames();
            if (this.GameList.Where(x => x.RefreshAchievements == true).Count() > 0) {
#if WINDOWS_APP
                StartLibraryRefresh();
#endif
            }
            base.TrackEvent("Navigation", "Loaded", "Library");
        }

        public async Task GetGames() {
            this.IsLoading = true;

            var gameList = await playerLibService.GetPlayerLibraryCached(base.UserID);

            if (Settings.Profile.GetGamesWOAchievements == false) {
                //gameList = gameList.Where(x => x.StatsLink != null && !string.IsNullOrEmpty(x.StatsLink)).ToList();
                gameList = gameList.Where(x => x.HasAchievements == true && x.StatsLink != string.Empty).ToList();
            }
            if (ShowOneEarned == true) {
                gameList = gameList.Where(x => x.AchievementsEarned > 0).ToList();
            }

            gameList = gameList.ToList();

            GameList = ApplySort(gameList);

            this.IsLoading = false;
        }

        public async void StartLibraryRefresh() {
            if (!base.HasNetwork()) {
                return;
            }

            this.IsRefreshing = true;
            cancelLibrary = new CancellationTokenSource();
            var progressIndicator = new Progress<int>(ReportProgress);

            var gameList = await playerLibService.GetPlayerLibraryCached(base.UserID);
            gameList = ApplySort(gameList);

            RefreshCount = gameList.Where(x => x.RefreshAchievements == true && x.StatsLink != string.Empty).Count();
            try {
                var gToRefresh = gameList.Where(x => x.RefreshAchievements == true && x.StatsLink != string.Empty).ToList();
                await playerStatsService.UpdateStatsByList(gToRefresh, progressIndicator, cancelLibrary.Token);
            } catch (OperationCanceledException ex) {
                //Do stuff to handle cancellation
            }

            await GetGames();
            this.IsRefreshing = false;
            LibProgress = "";
        }


        public void StopLibraryRefresh() {
            if (cancelLibrary != null) {
                Debug.WriteLine("Actual stop");
                cancelLibrary.Cancel();
                this.IsRefreshing = false;
                LibProgress = "";

            }
        }

        public void ReportProgress(int value) {
            if (IsRefreshing != false) {
                LibProgress = string.Format("Updating: {0} out of {1}", value, RefreshCount);
            } else {
                LibProgress = "";
            }

            if (value > 0 && value % 15 == 0) {
                //RefreshUI
                GetGames();
            }
            Debug.WriteLine(LibProgress);

        }


        public override void UnLoad(object parameter) {
            StopLibraryRefresh();
        }
    }


}

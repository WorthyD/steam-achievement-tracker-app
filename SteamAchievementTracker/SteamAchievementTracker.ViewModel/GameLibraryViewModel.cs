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

namespace SteamAchievementTracker.ViewModel
{
    public class GameLibraryViewModel : BaseViewModel, IGameLibraryViewModel
    {
        //Services
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;
        private IPlayerStatsService playerStatsService;

        private List<IGame> _gameList;
        public List<IGame> GameList
        {
            get { return _gameList; }
            set
            {
                Set(() => GameList, ref _gameList, value);
            }
        }
        private string _libProgress;
        public string LibProgress
        {
            get
            {
                return LibProgress;
            }
            set
            {
                Set(() => LibProgress, ref _libProgress, value);
            }
        }

        private const string titleAsc = "Title - Asc";
        private const string titleDsc = "Title - Desc";
        private const string playTimeAsc = "Playtime - Asc";
        private const string playTimeDsc = "Playtime - Desc";
        private const string progressAsc = "Progress - Asc";
        private const string progressDsc = "Progress - Desc";
        private const string achCountAsc = "Achievement Count - Asc";
        private const string achCountDesc = "Achievement Count - Desc";

        private CancellationTokenSource cancelLibrary;

        public ObservableCollection<string> SortLib
        {
            get
            {
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
        public string SelectedSort
        {
            get { return _mySelectedItem; }
            set
            {
                if (_mySelectedItem != value)
                {

                    Debug.WriteLine("UpdatingSelected Item");
                    Set(() => SelectedSort, ref _mySelectedItem, value);

                    Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"] = value;
                    if (GameList != null)
                    {
                        GameList = ApplySort(GameList);
                    }
                }
            }
        }

        //Events 
        public RelayCommand<ItemClickEventArgs> OpenGame { get; set; }
        public RelayCommand StartRefresh { get; set; }
        public RelayCommand CancelRefresh { get; set; }






        public GameLibraryViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService, IPlayerStatsService _playerStatsService)
            : base(_navigationService)
        {
            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;
            this.playerStatsService = _playerStatsService;

            if (base.IsInDesignMode)
            {
                this.Initialize(null);
            }
            if (Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"] != null)
            {
                SelectedSort = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"].ToString();
            }
            else
            {
                SelectedSort = titleAsc;
            }

            this.InitializeCommands();
        }
        private List<IGame> ApplySort(List<IGame> list)
        {
            if (list == null) return null;

            string sort = titleAsc;

            if (Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"] != null)
            {
                sort = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["SortOrder"].ToString();
            }


            switch (sort)
            {
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


        private void InitializeCommands()
        {
            OpenGame = new RelayCommand<ItemClickEventArgs>(game =>
            {
                var x = (IGame)game.ClickedItem;
                var pageType = SimpleIoc.Default.GetInstance<IGameDetailsView>();
                navigationService.Navigate(pageType.GetType(), x.AppID);
                Debug.WriteLine("Click - " + x.AppID);
            });
            StartRefresh = new RelayCommand(() =>
            {
                StartLibraryRefresh();
            });
            CancelRefresh = new RelayCommand(() =>
            {
                StopLibraryRefresh();
            });
        }
        public async void Initialize(object parameter)
        {

            if (base.UserID == 0)
            {
                //Return login
                base.UserID = 76561198025095151;
                base.UserName = "WorthyD";
            }

            var gameList = await playerLibService.GetPlayerLibraryCached(base.UserID);

            //TODO: Check settings;
            if (true)
            {
                gameList = gameList.Where(x => x.StatsLink != null && !string.IsNullOrEmpty(x.StatsLink)).ToList();
            }
            GameList = ApplySort(gameList);

            //Todo: Move to button task
        }


        public void StartLibraryRefresh()
        {
            cancelLibrary = new CancellationTokenSource();
            var progressIndicator = new Progress<string>(ReportProgress);
            //List<string> gameStats = GameList.Select(x => x.StatsLink).ToList();
            playerStatsService.UpdateStatsByList(GameList, progressIndicator, cancelLibrary.Token);

        }

        public void StopLibraryRefresh()
        {
            if (cancelLibrary != null)
            {
                cancelLibrary.Cancel();
            }
        }

        public void ReportProgress(string value)
        {
            Debug.WriteLine(value);
        }
    }


}

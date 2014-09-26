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
    public class GameLibraryViewModel : BaseViewModel, IGameLibraryViewModel
    {
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;

        private IPlayerLibrary _library;
        public IPlayerLibrary Library
        {
            get { return _library; }
            set
            {
                Set(() => Library, ref _library, value);
            }
        }

        public GameLibraryViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService)
            : base(_navigationService){
                this.navigationService = _navigationService;
                this.playerLibService = _playerLibService;

                if (base.IsInDesignMode)
                {
                    this.Initialize(null);
                }
                this.InitializeCommands();
        }
        public RelayCommand<ItemClickEventArgs> OpenGame
        {
            get;
            set;
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

            Library = new PlayerLibrary()
            {
                GameList = gameList.ToList()
            };
        }
    }

    //public class GameListItemViewModel : IGame
    //{
    //    public GameListItemViewModel(IGame g)
    //    {
    //        this.SteamUserID = g.SteamUserID;
    //        this.AppID = g.AppID;
    //        this.Name = g.Name;
    //        this.StatsLink = g.StatsLink;
    //        this.GameLink = g.GameLink;
    //        this.Logo = g.Logo;
    //        this.HoursPlayed = g.HoursPlayed;
    //        this.RecentHours = g.RecentHours;
    //        this.LastUpdated = g.LastUpdated;
    //        this.AchievementRefresh = g.AchievementRefresh;
    //        this.AchievementsEarned = g.AchievementsEarned;
    //        this.TotalAchievements = g.TotalAchievements;
    //    }


    //    public long SteamUserID { get; set; }
    //    public int AppID { get; set; }
    //    public string Name { get; set; }
    //    public string StatsLink { get; set; }
    //    public string GameLink { get; set; }
    //    public string Logo { get; set; }

    //    public decimal HoursPlayed { get; set; }

    //    public decimal RecentHours { get; set; }

    //    public DateTime LastUpdated { get; set; }

    //    public DateTime AchievementRefresh { get; set; }

    //    public int AchievementsEarned { get; set; }

    //    public int TotalAchievements { get; set; }

    //    public string PercentComplete
    //    {
    //        get
    //        {
    //            return (AchievementsEarned / TotalAchievements).ToString();                //return AchievementsEarned / TotalAchievements;
    //        }
    //    }

    //    public string ProgressText
    //    {
    //        get
    //        {
    //            return string.Format("{0} of {1}", AchievementsEarned, TotalAchievements);
    //        }
    //    }
    //    public bool HasAchievements { get { return !string.IsNullOrEmpty(this.StatsLink); } }
    //    public bool BeenProcessed { get { return this.LastUpdated > new DateTime(1900, 2, 1); } }
    //}
}

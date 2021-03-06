using GalaSoft.MvvmLight.Command;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.ViewModels;
using SteamAchievementTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel {
    public class GameDetailsViewModel : BaseViewModel, IGameDetailsViewModel {
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;
        private IPlayerStatsService statService;

        #region Commands
        public RelayCommand LaunchGame { get; set; }
        #endregion

        public GameDetailsViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService, IPlayerStatsService _statService)
            : base(_navigationService) {

            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;
            this.statService = _statService;

            this.InitializeCommands();

            if (base.IsInDesignMode) {
                this.Initialize(null);
            }
        }


        private IGame _game;
        public IGame Game { get { return _game; } set { Set(() => Game, ref _game, value); } }

        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { Set(() => IsLoading, ref _IsLoading, value); } }

        private bool _started;
        public bool Started { get { return _started; } set { Set(() => Started, ref _started, value); } }

        private bool _completed;
        public bool Completed { get { return _completed; } set { Set(() => Completed, ref _completed, value); } }


        public int UnLockedCount { get { return UnlockedAchievements.Count(); } }
        private List<IGameAchievement> _UnlockedAchievements;
        public List<IGameAchievement> UnlockedAchievements {
            get { return _UnlockedAchievements; }
            set {
                Set(() => UnlockedAchievements, ref  _UnlockedAchievements, value);
            }
        }


        public int LockedCount { get { return LockedAchievements.Count(); } }
        private List<IGameAchievement> _LockedAchievements;
        public List<IGameAchievement> LockedAchievements {
            get { return _LockedAchievements; }
            set {
                Set(() => LockedAchievements, ref _LockedAchievements, value);
            }
        }
        private void InitializeCommands() {
            LaunchGame = new RelayCommand(() => {
                LaunchExternalGame();
            });
        }
        private void LaunchExternalGame() {
            Uri gameUrl = new Uri(string.Format("steam://rungameid/{0}", this.Game.AppID));

            Windows.System.Launcher.LaunchUriAsync(gameUrl);
        }

        public async override void Initialize(object parameter) {
            base.Initialize(parameter);
            this.IsLoading = true;

            this.LockedAchievements = new List<IGameAchievement>();
            this.UnlockedAchievements = new List<IGameAchievement>();
            this.Game = new Game();


            long gameId = 0;

            if (parameter != null) {
                long.TryParse(parameter.ToString(), out gameId);
            }

            this.Game = this.playerLibService.GetGameByID(gameId, base.UserID);
            List<IGameAchievement> Achievements = new List<IGameAchievement>();

            Achievements = this.statService.GetGameAchievementsCached(this.Game.StatsLink);

            if (Achievements.Count > 0) {
                this.IsLoading = false;

                this.LockedAchievements = Achievements.Where(x => x.IsUnlocked == false).ToList();
                this.UnlockedAchievements = Achievements.Where(x => x.IsUnlocked == true).ToList();

                this.Started = this.UnlockedAchievements.Count() > 0;
                this.Completed = this.Game.AchievementsEarned == this.Game.TotalAchievements;


            }



            RefreshAchievements();

            base.TrackEvent("Navigation", "Loaded", string.Format("Game Details {0}", this.Game.Name));
        }

        public async Task RefreshAchievements() {
            if (!string.IsNullOrEmpty(this.Game.StatsLink)) {
                List<IGameAchievement> Achievements = new List<IGameAchievement>();
                if (base.HasNetwork()) {
                    Achievements = await this.statService.GetFreshStats(this.Game.StatsLink);
                }
                var g = this.playerLibService.GetGameByID(this.Game.AppID, base.UserID);
                //Update display Data
                if (g.AchievementsEarned != this.Game.AchievementsEarned || g.AchievementsEarned == 0) {
                    this.Game = g;

                    this.LockedAchievements = Achievements.Where(x => x.IsUnlocked == false).ToList();
                    this.UnlockedAchievements = Achievements.Where(x => x.IsUnlocked == true).ToList();
                    this.Started = this.UnlockedAchievements.Count() > 0;
                    this.Completed = this.Game.AchievementsEarned == this.Game.TotalAchievements;
                }
            }
            this.IsLoading = false;

        }

    }
}

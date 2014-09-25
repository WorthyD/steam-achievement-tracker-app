using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class GameDetailsViewModel : BaseViewModel, IGameDetailsViewModel
    {
        private IPlayerLibraryService playerLibService;
        private INavigationService navigationService;
        private IPlayerStatsService statService;

        public GameDetailsViewModel(INavigationService _navigationService, IPlayerLibraryService _playerLibService, IPlayerStatsService _statService)
            : base(_navigationService)
        {


            this.navigationService = _navigationService;
            this.playerLibService = _playerLibService;
            this.statService = _statService;

            if (base.IsInDesignMode)
            {
                this.Initialize(null);
            }
        }


        private IGame _game;
        public IGame Game { get { return _game; } set { Set(() => Game, ref _game, value); } }

        public int UnLockedCount { get { return UnlockedAchievements.Count(); } }
        private List<IGameAchievement> _UnlockedAchievements;
        public List<IGameAchievement> UnlockedAchievements
        {
            get { return _UnlockedAchievements; }
            set
            {
                Set(() => UnlockedAchievements, ref  _UnlockedAchievements, value);
            }
        }


        public int LockedCount { get { return LockedAchievements.Count(); } }
        private List<IGameAchievement> _LockedAchievements;
        public List<IGameAchievement> LockedAchievements
        {
            get { return _LockedAchievements; }
            set
            {
                Set(() => LockedAchievements, ref _LockedAchievements, value);
            }
        }

        public async void Initialize(object parameter)
        {
            long gameId = 0;

            if (parameter != null)
            {
                long.TryParse(parameter.ToString(), out gameId);
            }

            this.Game = this.playerLibService.GetGameByID(gameId, base.UserID);
            List<IGameAchievement> Achievements = new List<IGameAchievement>();
            if (!string.IsNullOrEmpty(this.Game.StatsLink))
            {

                if (this.Game.AchievementRefresh < DateTime.Now.AddMinutes(Settings.GameAchievement.StatRefreshInterval) || this.Game.TotalAchievements == 0)
                {
                    Achievements = await this.statService.GetFreshStats(this.Game.StatsLink);
                }
                else
                {
                    Achievements = this.statService.GetGameAchievementsCached(this.Game.StatsLink);
                }

            }

            this.LockedAchievements = Achievements.Where(x => x.IsUnlocked == false).ToList();
            this.UnlockedAchievements = Achievements.Where(x => x.IsUnlocked == true).ToList();

        }
    }
}

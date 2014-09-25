using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.ViewModels
{
    public interface IGameDetailsViewModel : IViewModel
    {
        IGame Game { get; set; }

        int UnLockedCount { get; }
        List<IGameAchievement> UnlockedAchievements { get; set; }

        int LockedCount { get; }
        List<IGameAchievement> LockedAchievements { get; set; }

    }
}

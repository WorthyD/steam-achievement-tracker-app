using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.ViewModels
{
    public interface IMainViewModel : IViewModel
    {
        string Title { get; set; }
        IProfile Profile { get; set; }
        IPlayerLibrary Library { get; set; }
    }
}

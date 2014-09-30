using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.ViewModels
{
    public interface IGameLibraryViewModel : IViewModel
    {

        List<IGame> GameList { get; set; }
    }
}

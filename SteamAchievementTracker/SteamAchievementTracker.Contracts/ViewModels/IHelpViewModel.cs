using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.ViewModels
{
    public interface IHelpViewModel : IViewModel
    {
        string VideoContent { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models
{
    public interface IGameAchievement
    {
        long AppId { get; set; }
        string Name { get; set; }
        string DisplayName { get; set; }
        string Description { get; set; }
        bool Hidden { get; set; }
        string Icon { get; set; }
        string IconGray { get; set; }
        double Percent { get; set; }


    }
}

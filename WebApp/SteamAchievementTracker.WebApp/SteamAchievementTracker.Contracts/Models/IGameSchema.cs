using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models
{
    public interface IGameSchema
    {
        long AppId { get; set; }
        string Name { get; set; }
        DateTime LastSchemaUpdate { get; set; }
        bool HasAchievements { get; set; }
        List<IGameAchievement> GameAchievements { get; set; }
    }
}

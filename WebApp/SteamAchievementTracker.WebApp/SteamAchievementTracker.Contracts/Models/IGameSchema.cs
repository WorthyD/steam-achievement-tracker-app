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
        string Img_Icon_Url { get; set; }
        string Img_Logo_Url { get; set; }
        bool has_community_visible_stats { get; set; }
        DateTime LastSchemaUpdate { get; set; }
        int AvgUnlock { get; set; }
        bool HasAchievements { get; set; }
    }
}

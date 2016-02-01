using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.ViewModels
{
    public class PlayerProfile : IPlayerProfile
    {
        public long SteamId { get; set; }
        public string PersonaName { get; set; }
        public string RealName { get; set; }
        public string AvatarFull { get; set; }
        public string ProfileUrl { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime LibraryLastUpdate { get; set; }

    }
}

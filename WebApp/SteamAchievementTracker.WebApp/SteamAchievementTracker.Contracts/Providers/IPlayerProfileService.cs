using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Providers {
    public interface IPlayerProfileService {
        //Task<IPlayerProfile> GetFreshPlayerDetails(string SteamID, bool update);
        Task<IPlayerProfile> GetProfile(string steamId);
        //Task<IPlayerProfile> GetProfileCached(long steam64ID, string steamID);
    }
}

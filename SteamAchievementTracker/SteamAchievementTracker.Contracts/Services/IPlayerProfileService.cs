using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Services
{
    public interface IPlayerProfileService
    {
        Task<IProfile> GetPlayerDetails(string SteamID);
        Task<IProfile> GetProfileFromDB(long steam64ID);
        Task<IProfile> GetProfileCached(long steam64ID, string steamID);
    }
}

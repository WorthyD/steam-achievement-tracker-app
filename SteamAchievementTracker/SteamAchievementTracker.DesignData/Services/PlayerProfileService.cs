using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Services
{
    public class PlayerProfileService : IPlayerProfileService
    {
        public async Task<Contracts.Model.IProfile> GetPlayerDetails(string SteamID)
        {
            return new Model.Profile();
        }

        public async Task<Contracts.Model.IProfile> GetProfileFromDB(long steam64ID)
        {

            return new Model.Profile();
        }

        public async Task<Contracts.Model.IProfile> GetProfileCached(long steam64ID, string steamID)
        {

            return new Model.Profile();
        }


    }
}

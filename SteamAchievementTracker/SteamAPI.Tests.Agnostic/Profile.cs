using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Tests.Agnostic {
    public class Profile {
        public static async Task<bool> GetPlayerProfileByName() {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = "WorthyD";
            var response = await request.GetResponse();
            var profile = response.Profile;
            return AnythingEmpty(profile);
        }
        public static async Task<bool> GetPlayerProfileByID() {
            //76561197970557943
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = "76561197970557943";
            var response = await request.GetResponse();
            var profile = response.Profile;
            return AnythingEmpty(profile);
        }

        public static async Task<bool> GetPlayerProfileByNameLIGHT() {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = "WorthyD";
            var response = await request.GetLightResponse();
            var profile = response;
            return AnythingLightEmpty(profile);
        }
        public static async Task<bool> GetPlayerProfileByIDLIGHT() {
            //76561197970557943
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = "76561197970557943";
            var response = await request.GetLightResponse();
            var profile = response;
            return AnythingLightEmpty(profile);
        }


        public static bool GetPlayerProfileFail() {
            return false;
        }
        public static bool AnythingLightEmpty(ViewModels.ProfileViewModel p) {

            if (p.AvatarFull.IsEmpty() ||
                //p.CustomURL.IsEmpty() ||
                p.RealName.IsEmpty() ||
                p.SteamID.IsEmpty() ||
                p.SteamID64.ToString().IsEmpty()) {
                return false;
            }

            if (p.RecentGameLinks.Count() == 0) {
                return false;
            }

            return true;
        }

        public static bool AnythingEmpty(Models.Profile.profile p) {

            if (p.steamID.IsEmpty() ||
                p.avatarIcon.IsEmpty() ||
                p.avatarMedium.IsEmpty() ||
                p.avatarFull.IsEmpty() ||
                p.realname.IsEmpty()) {
                return false;
            }

            if (p.mostPlayedGames.Count() == 0) {
                return false;
            }

            return true;
        }
    }
}

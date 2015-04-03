using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.ViewModels {
    public class ProfileViewModel {
        public long SteamID64 { get; set; }
        public string SteamID { get; set; }
        public string AvatarFull { get; set; }
        public string CustomURL { get; set; }
        public string RealName { get; set; }
        public List<string> RecentGameLinks { get; set; }

        public ProfileViewModel() {
            this.SteamID64 = 0;
            this.SteamID = string.Empty;
            this.AvatarFull = string.Empty;
            this.CustomURL = string.Empty;
            this.RealName = string.Empty;
            this.RecentGameLinks = new List<string>();
        }
        public ProfileViewModel(Models.Profile.profile p) {
            this.SteamID64 = p.steamID64;
            this.SteamID = p.steamID;
            this.AvatarFull = p.avatarFull;
            this.CustomURL = p.customURL;
            this.RealName = p.realname;
            this.RecentGameLinks = new List<string>();

            if (p.mostPlayedGames != null) {
                this.RecentGameLinks = p.mostPlayedGames.Select(x => x.gameLink).ToList();
            }
        }
    }
}

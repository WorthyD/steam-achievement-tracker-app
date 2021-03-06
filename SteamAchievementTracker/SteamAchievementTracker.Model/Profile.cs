using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Model
{
    public class Profile : IProfile
    {
        public long ID64 { get; set; }
        public string ID { get; set; }

        public string Name { get; set; }
        public string ThumbURL { get; set; }

        public List<IGame> RecentGames { get; set; }
        public List<string> RecentGameLinks { get; set; }

        public DateTime LastUpdate { get; set; }

        public Profile()
        {
            this.ID = string.Empty;
            this.ID64 = 0;
            this.Name = string.Empty;
            this.ThumbURL = string.Empty;
            this.RecentGames = new List<IGame>();
            this.RecentGameLinks = new List<string>();
            this.LastUpdate = DateTime.MinValue;
        }

        public Profile(SteamAPI.Models.Profile.profile profile)
        {
            this.ID = (string.IsNullOrEmpty( profile.customURL))? profile.steamID64.ToString() : profile.customURL;
            this.ID64 = profile.steamID64;
            this.Name = profile.realname;
            this.ThumbURL = profile.avatarFull;

            this.RecentGames = new List<IGame>();
            this.RecentGameLinks = new List<string>();
            if (profile.mostPlayedGames != null)
            {
                foreach (var game in profile.mostPlayedGames)
                {
                    this.RecentGames.Add(new Game()
                    {
                        GameLink = game.gameLink,
                        Name = game.gameName,
                        Logo = game.gameLogoSmall,
                        RecentHours = game.hoursOnRecord,
                        HoursPlayed = game.hoursOnRecord
                    });
                }
                this.RecentGameLinks = profile.mostPlayedGames.Select(x => x.gameLink).ToList();

            }
        }
        public Profile(long id64, string id, string name, string thumbnailurl, DateTime lastUpdate)
        {
            this.ID64 = id64;
            this.ID = id;
            this.Name = name;
            this.ThumbURL = thumbnailurl;

            this.RecentGames = new List<IGame>();
            this.RecentGameLinks = new List<string>();
            this.LastUpdate = lastUpdate;
        }
    }
}

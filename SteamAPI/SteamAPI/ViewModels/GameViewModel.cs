using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.ViewModels {
    public class GameViewModel {
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string StoreLink { get; set; }
        public string StatsLink { get; set; }
        public decimal HoursOnRecord { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models
{
    public interface ILogin
    {
        long SteamId { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }

}

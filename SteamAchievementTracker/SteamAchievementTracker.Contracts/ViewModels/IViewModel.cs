using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.ViewModels
{
    public interface IViewModel
    {
         void Initialize(object parameter);
         void Load(object parameter);
         void UnLoad(object parameter);
    }
}

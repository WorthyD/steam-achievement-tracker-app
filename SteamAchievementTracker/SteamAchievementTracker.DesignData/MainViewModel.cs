using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData
{
    public class MainViewModel : IMainViewModel
    {

        string IMainViewModel.Title
        {
            get
            {
                return "Steam Achievement Design Time";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  Contracts.Model.IProfile Profile
        {
            get;
            set;
        }

        public  Contracts.Model.IPlayerLibrary Library
        {
            get;
            set;
        }

        public MainViewModel() {
            this.Profile = new Model.Profile();

            this.Library = new Model.PlayerLibrary();
        }

        void IViewModel.Initialize(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}

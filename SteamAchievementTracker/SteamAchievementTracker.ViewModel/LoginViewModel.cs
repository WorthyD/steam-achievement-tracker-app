using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                Set(() => UserName, ref _UserName, value);
            }
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get { return _validationMessage; }
            set
            {
                Set(() => ValidationMessage, ref _validationMessage, value);
            }
        }


        private bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                Set(() => IsVisible, ref _IsVisible, value);
            }
        }

        public IPlayerProfileService playerProfService;
        public IPlayerLibraryService playerLibService;

        public RelayCommand Login { get; set; }

        public void InitializeCommands()
        {
            Login = new RelayCommand(() =>
            {
                LoginUser();
            });
        }

        private async Task LoginUser()
        {

            var p = await playerProfService.GetFreshPlayerDetails(this.UserName, false);
            if (p != null && p.ID64 != 0)
            {
                await playerLibService.GetPlayerLibraryRefresh(p.ID64, p.ID);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = p.ID64;
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = p.ID;

                //TODO:
                //Call base viewmodel to load info
             Messenger.Default.Send("LoggedIn");

                this.IsVisible = false;
            }
            else
            {
                //TODO:
                //show validation message
            }

            Debug.WriteLine(this.UserName);
        }
     
    }
}

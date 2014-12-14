using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Google.Apis.Analytics;

namespace SteamAchievementTracker.ViewModel {
    public class LoginViewModel : ViewModelBase {
        private string _UserName;
        public string UserName {
            get { return _UserName; }
            set {
                Set(() => UserName, ref _UserName, value);
            }
        }

        //private string _validationMessage;
        //public string ValidationMessage
        //{
        //    get { return _validationMessage; }
        //    set
        //    {
        //        Set(() => ValidationMessage, ref _validationMessage, value);
        //    }
        //}


        private bool _IsVisible;
        public bool IsVisible {
            get { return _IsVisible; }
            set {
                Set(() => IsVisible, ref _IsVisible, value);
            }
        }

        private bool _IsLoggingIn;
        public bool IsLoggingIn {
            get { return _IsLoggingIn; }
            set {
                Set(() => IsLoggingIn, ref _IsLoggingIn, value);
            }
        }

        private string _LoginMessage;
        public string LoginMessage {
            get { return _LoginMessage; }
            set {
                Set(() => LoginMessage, ref _LoginMessage, value);
            }
        }

        private string _ErrorMessage;
        public string ErrorMessage {
            get { return _ErrorMessage; }
            set {
                Set(() => ErrorMessage, ref _ErrorMessage, value);
            }
        }

        public IPlayerProfileService playerProfService;
        public IPlayerLibraryService playerLibService;

        public RelayCommand Login { get; set; }
        public RelayCommand GoHelp { get; set; }

        public void InitializeCommands() {
            Login = new RelayCommand(() => {
                LoginUser();
            });

            GoHelp = new RelayCommand(() => {
                var pageType = SimpleIoc.Default.GetInstance<IHelp>();
                INavigationService _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
                _navigationService.Navigate(pageType.GetType(), null);
            });
        }

        private async Task LoginUser() {
            this.IsLoggingIn = true;
            this.ErrorMessage = "";
            this.LoginMessage = "Logging User In";
            IProfile p = new Profile();
            ITrackingService _trackingService = ServiceLocator.Current.GetInstance<ITrackingService>();

            try {
                p = await playerProfService.GetFreshPlayerDetails(this.UserName, false);

            } catch (SteamAPI.Player.Exceptions.PlayerNotFoundException) {


                _trackingService.TrackEvent("Login", "Error", this.UserName);
                p = null;
                this.ErrorMessage = "User Not Found";
            }

            if (p != null && p.ID64 != 0) {
                _trackingService.TrackEvent("Login", "Success", this.UserName);

                this.LoginMessage = "Getting User Library";

                List<IGame> games = await playerLibService.GetPlayerLibraryRefresh(p.ID64, p.ID);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = p.ID64;
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = p.ID;
                _trackingService.TrackEvent("Library Count", "Login", games.Count().ToString());



                Messenger.Default.Send("LoggedIn");

                this.LoginMessage = string.Empty;
                this.IsVisible = false;
            }

            this.IsLoggingIn = false;
            Debug.WriteLine(this.UserName);
        }

    }
}

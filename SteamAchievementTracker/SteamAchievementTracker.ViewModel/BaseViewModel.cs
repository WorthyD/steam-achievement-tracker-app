using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SteamAchievementTracker.Contracts.Services;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace SteamAchievementTracker.ViewModel {
    public class BaseViewModel : ViewModelBase, IViewModel {
        #region Commands
        public RelayCommand GoBack { get; set; }
        public RelayCommand GoLibrary { get; set; }
        public RelayCommand GoHome { get; set; }
        public RelayCommand GoHelp { get; set; }
        public RelayCommand GoSettings { get; set; }
        #endregion

        #region Properties


        public bool CanGoBack {
            get {
                return this._navigationService.CanGoBack(); ;
            }
        }
        public long UserID {
            get {
                long tLong = 0;
                var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"];
                if (setting != null) {
                    long.TryParse(setting.ToString(), out tLong);
                }

                this.IsLoggedIn = (tLong > 0);
                return tLong;

            }
            set {

                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = value;
            }
        }

        public string UserName {
            get {
                string tUser = string.Empty;
                var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"];
                if (setting != null) {
                    Debug.WriteLine("Getting UserName" + ToString());
                    return setting.ToString();
                }
                return string.Empty;
            }
            set {
                Debug.WriteLine("Setting Name " + value);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = value;
            }
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn { get { return _isLoggedIn; } set { Set(() => IsLoggedIn, ref _isLoggedIn, value); } }

        public bool HasNetwork() {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            return (connectionProfile != null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
        }
        #endregion

        public virtual void Initialize(object parameter) {
            //SettingsPane.GetForCurrentView().CommandsRequested += ViewModel_CommandsRequested;
            var iSettings = SimpleIoc.Default.GetInstance<ISettingsViewModel>();
            iSettings.Initialize();

        }

        public virtual void DeInitialize() {
            var iSettings = SimpleIoc.Default.GetInstance<ISettingsViewModel>();
            iSettings.DeInitialize();
        }

        private readonly INavigationService _navigationService;
        private readonly ITrackingService _trackingService;
        public BaseViewModel(INavigationService navigationService) {
            this._navigationService = navigationService;

            this.InitializeCommands();
        }

        private void InitializeCommands() {
            GoBack = new RelayCommand(() => {
                _navigationService.GoBack();
            });
            GoHome = new RelayCommand(() => {
                var pageType = SimpleIoc.Default.GetInstance<IMain>();
                _navigationService.Navigate(pageType.GetType(), null);

            });
            GoLibrary = new RelayCommand(() => {
                var pageType = SimpleIoc.Default.GetInstance<IGameLibrary>();
                _navigationService.Navigate(pageType.GetType(), null);
            });

            GoHelp = new RelayCommand(() => {
                Uri helpUrl = new Uri("http://steamachievementtracker.com/help/winrt");
                Windows.System.Launcher.LaunchUriAsync(helpUrl);

            });

            GoSettings = new RelayCommand(() => {
#if WINDOWS_APP
                var iSettings = SimpleIoc.Default.GetInstance<ISettingsViewModel>();
                iSettings.ShowSettings();
#else
                var pageType = SimpleIoc.Default.GetInstance<IMainSettings>();
                _navigationService.Navigate(pageType.GetType(), null);
#endif
            });
        }


        private ITrackingService _tracker;
        private ITrackingService TrackingService {
            get {
                if (_tracker == null) {
                    _tracker = ServiceLocator.Current.GetInstance<ITrackingService>();
                }
                return _tracker;
            }
        }
        public void TrackEvent(string cat, string action, string label) {
            TrackingService.TrackEvent(cat, action, label);
        }




        public virtual void Load(object parameter) {
        }

        public virtual void UnLoad(object parameter) {
        }
    }
}

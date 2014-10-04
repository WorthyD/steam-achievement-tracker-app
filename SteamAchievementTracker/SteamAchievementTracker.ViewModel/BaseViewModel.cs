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

namespace SteamAchievementTracker.ViewModel
{
    public class BaseViewModel : ViewModelBase, IViewModel
    {
        #region Commands
        public RelayCommand GoBack { get; set; }
        public RelayCommand GoLibrary { get; set; }
        public RelayCommand GoHome { get; set; }
        #endregion

        #region Properties
        public long UserID
        {
            get
            {
                long tLong = 0;
                var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"];
                if (setting != null)
                {
                    long.TryParse(setting.ToString(), out tLong);
                    Debug.WriteLine("Retreiving UserID " + tLong);
                }
                return tLong;

            }
            set
            {

                Debug.WriteLine("Setting UserID " + value);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID64"] = value;
            }
        }

        public string UserName
        {
            get
            {
                string tUser = string.Empty;
                var setting = Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"];
                if (setting != null)
                {
                    Debug.WriteLine("Getting UserName" + ToString());
                    return setting.ToString();
                }
                return string.Empty;
            }
            set
            {
                Debug.WriteLine("Setting Name " + value);
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["ID"] = value;
            }
        }
        #endregion

        public virtual void Initialize(object parameter)
        {
            //SettingsPane.GetForCurrentView().CommandsRequested += ViewModel_CommandsRequested;
            var iSettings = SimpleIoc.Default.GetInstance<ISettingsViewModel>();
            iSettings.Initialize();
 
        }

        public virtual void DeInitialize()
        {
            var iSettings = SimpleIoc.Default.GetInstance<ISettingsViewModel>();
            iSettings.DeInitialize();
        }

        private readonly INavigationService _navigationService;
        public BaseViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            GoBack = new RelayCommand(() =>
            {
                _navigationService.GoBack();
            });
            GoHome = new RelayCommand(() =>
            {
                _navigationService.GoBack();

            });
            GoLibrary = new RelayCommand(() =>
            {
                var pageType = SimpleIoc.Default.GetInstance<IGameLibrary>();
                _navigationService.Navigate(pageType.GetType(), null);
            });

       }




    }
}

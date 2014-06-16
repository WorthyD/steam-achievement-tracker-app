using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamAchievementTracker.App.ViewModel {
    public class MainViewModel : BaseViewModel {
        //public MainViewModel(Common.NavigationHelper navigationService)
        //    : base(navigationService) {
        //    HelloWorld = IsInDesignMode
        //       ? "Runs in design mode"
        //       : "Runs in runtime mode";

        //}

        [PreferredConstructor]
        public MainViewModel()
            : base() {
            _profile = new DataModel.PlayerProfile();

            _title = "Steam Achievement Tracker";

            if (IsInDesignMode) {
                _profile.PopulateDesignData();
                return;
            }



        }

        private string _title;
        public string Title {
            get { return _title; }
            set {
                Set(() => Title, ref _title, value);
            }
        }

        private DataModel.PlayerProfile _profile;

        public DataModel.PlayerProfile Profile {
            get {
                return _profile;
            }
            set {
                Set(() => Profile, ref _profile, value);
            }
        }



    }
}

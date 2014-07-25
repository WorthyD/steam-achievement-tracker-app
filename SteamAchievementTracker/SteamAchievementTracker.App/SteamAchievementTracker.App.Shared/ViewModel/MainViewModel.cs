using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            _profile = new DataAccess.Model.Profile();
            _library = new DataAccess.Model.PlayerLibrary();

            _title = "Steam Achievement Tracker";

            if (IsInDesignMode) {
                _profile.PopulateDesignData();
                _library.PopulateDesignData();
                return;
            }




            LoadRealData();
        }

        public async void LoadRealData() {
            DataAccess.Repository.PlayerProfileRepository _playerRepo = new DataAccess.Repository.PlayerProfileRepository();
            DataAccess.Repository.PlayerLibraryRepository _libraryRepo = new DataAccess.Repository.PlayerLibraryRepository();


            Profile = await _playerRepo.GetPlayerDetails("WorthyD");
            //_library = await _libraryRepo.GetPlayerLibrary("WorthyD");
        }

        private string _title;
        public string Title {
            get { return _title; }
            set {
                Set(() => Title, ref _title, value);
            }
        }

        private DataAccess.Model.Profile _profile;

        public DataAccess.Model.Profile Profile {
            get {
                return _profile;
            }
            set {
                Set(() => Profile, ref _profile, value);
            }
        }

        private DataAccess.Model.PlayerLibrary _library;
        public DataAccess.Model.PlayerLibrary Library {
            get { return _library; }
            set {
                Set(() => Library, ref _library, value);
            }
        }


    }
}

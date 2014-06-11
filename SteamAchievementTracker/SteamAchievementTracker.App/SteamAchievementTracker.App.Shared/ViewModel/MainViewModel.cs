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
            HelloWorld = IsInDesignMode
               ? "Runs in design mode"
               : "Runs in runtime mode";

        }

        private string _helloWorld;

        public string HelloWorld {
            get {
                return _helloWorld;
            }
            set {
                Set(() => HelloWorld, ref _helloWorld, value);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using SteamAchievementTracker.App.Common;
using SteamAchievementTracker.Contracts.View;
using SteamAchievementTracker.Contracts.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SteamAchievementTracker.App.Views {
    public sealed partial class MainSettings : Page,  IMainSettings {
        public MainSettings() {
            this.InitializeComponent();
        }

        IViewModel IView.ViewModel {
            get { return this.DataContext as IViewModel; }
        }
    }
}

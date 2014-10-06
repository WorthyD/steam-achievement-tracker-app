using System;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SteamAchievementTracker.App.Views.PartialViews
{
    public sealed partial class StaticProgressBar : UserControl
    {
        public StaticProgressBar()
        {
            this.InitializeComponent();

            //double dc = this.DataContext as double;

            //double percent = 0;
            ////double.TryParse(dc, out percent);
            //double width = dc * this.canvas.ActualWidth;

            //this.bar.Height = this.canvas.ActualHeight;
            //this.bar.Width = width;
        }
    }
}

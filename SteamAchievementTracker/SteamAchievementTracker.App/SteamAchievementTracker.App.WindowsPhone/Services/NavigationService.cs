using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SteamAchievementTracker.App.Services {
    public class NavigationService : SteamAchievementTracker.Services.Infrastructure.NavigationService {

        public override void OnFrameNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e) {
            base.OnFrameNavigated(sender, e);
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e) {
            this.GoBack();
        }
        private void frame_Unloaded(object sender, RoutedEventArgs e) {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }
    }
}

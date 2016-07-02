using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SteamAchievementTracker.WebApi.Startup))]
namespace SteamAchievementTracker.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
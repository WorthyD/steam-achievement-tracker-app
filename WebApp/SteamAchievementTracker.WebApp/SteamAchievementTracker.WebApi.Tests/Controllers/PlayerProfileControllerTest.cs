using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamAchievementTracker.WebApi;
using SteamAchievementTracker.WebApi.Controllers;
using System.Threading.Tasks;


namespace SteamAchievementTracker.WebApi.Tests.Controllers
{
    [TestClass]
    public class PlayerProfileControllerTest
    {
        [TestMethod]
        public  async Task GetById() {
            PlayerProfileController controller = new PlayerProfileController();

            var response =  await controller.Get(76561198025095151);

            Assert.IsNotNull(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamAchievementTracker.Web.WebUI.Controllers {
    public class HelpController : Controller {
        // GET: Help
        public ActionResult Index() {
            return View();
        }
        public ActionResult WinRT() {
            return View();
        }
    }
}
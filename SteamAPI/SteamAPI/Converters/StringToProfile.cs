using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SteamAPI.Converters {
    public static class StringToProfile {
        public static Models.Profile.profile Convert(this string pro) {
            var m = new Models.Profile.profile();

            XDocument doc = XDocument.Parse(pro);
            m.avatarFull = doc.Root.Element("avatarFull").Value;

            return m;
        }
    }
}

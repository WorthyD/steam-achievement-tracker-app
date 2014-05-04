using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SteamAPI.Extensions {
    public static class Xml {
        public static T ParseXML<T>(this string data) where T : class, new() {
            if (data == null) {
                return null;
            }

            if (data.Trim().Length == 0) {
                return null;
            }

            var ser = new XmlSerializer(typeof(T));

            using (var sr = new StringReader(data)) {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}

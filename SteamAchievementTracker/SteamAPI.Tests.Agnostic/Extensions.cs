using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Tests.Agnostic {
    public static class Extensions {
        public static bool IsEmpty(this string s){
            return string.IsNullOrEmpty(s);
        }
    }
}

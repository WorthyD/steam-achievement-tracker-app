

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Models {
   public class ProfileGames {

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class gamesList {

            private ulong steamID64Field;

            private string steamIDField;

            private gamesListGame[] gamesField;

            /// <remarks/>
            public ulong steamID64 {
                get {
                    return this.steamID64Field;
                }
                set {
                    this.steamID64Field = value;
                }
            }

            /// <remarks/>
            public string steamID {
                get {
                    return this.steamIDField;
                }
                set {
                    this.steamIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("game", IsNullable = false)]
            public gamesListGame[] games {
                get {
                    return this.gamesField;
                }
                set {
                    this.gamesField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class gamesListGame {

            private uint appIDField;

            private string nameField;

            private string logoField;

            private string storeLinkField;

            private decimal hoursOnRecordField;

            private bool hoursOnRecordFieldSpecified;

            private string statsLinkField;

            private string globalStatsLinkField;

            /// <remarks/>
            public uint appID {
                get {
                    return this.appIDField;
                }
                set {
                    this.appIDField = value;
                }
            }

            /// <remarks/>
            public string name {
                get {
                    return this.nameField;
                }
                set {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string logo {
                get {
                    return this.logoField;
                }
                set {
                    this.logoField = value;
                }
            }

            /// <remarks/>
            public string storeLink {
                get {
                    return this.storeLinkField;
                }
                set {
                    this.storeLinkField = value;
                }
            }

            /// <remarks/>
            public decimal hoursOnRecord {
                get {
                    return this.hoursOnRecordField;
                }
                set {
                    this.hoursOnRecordField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool hoursOnRecordSpecified {
                get {
                    return this.hoursOnRecordFieldSpecified;
                }
                set {
                    this.hoursOnRecordFieldSpecified = value;
                }
            }

            /// <remarks/>
            public string statsLink {
                get {
                    return this.statsLinkField;
                }
                set {
                    this.statsLinkField = value;
                }
            }

            /// <remarks/>
            public string globalStatsLink {
                get {
                    return this.globalStatsLinkField;
                }
                set {
                    this.globalStatsLinkField = value;
                }
            }
        }
    }
}

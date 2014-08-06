using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Models {

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class playerstats {

        private string privacyStateField;

        private byte visibilityStateField;

        private playerstatsGame gameField;

        private playerstatsPlayer playerField;

        private playerstatsStats statsField;

        private playerstatsAchievement[] achievementsField;

        /// <remarks/>
        public string privacyState {
            get {
                return this.privacyStateField;
            }
            set {
                this.privacyStateField = value;
            }
        }

        /// <remarks/>
        public byte visibilityState {
            get {
                return this.visibilityStateField;
            }
            set {
                this.visibilityStateField = value;
            }
        }

        /// <remarks/>
        public playerstatsGame game {
            get {
                return this.gameField;
            }
            set {
                this.gameField = value;
            }
        }

        /// <remarks/>
        public playerstatsPlayer player {
            get {
                return this.playerField;
            }
            set {
                this.playerField = value;
            }
        }

        /// <remarks/>
        public playerstatsStats stats {
            get {
                return this.statsField;
            }
            set {
                this.statsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("achievement", IsNullable = false)]
        public playerstatsAchievement[] achievements {
            get {
                return this.achievementsField;
            }
            set {
                this.achievementsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class playerstatsGame {

        private string gameFriendlyNameField;

        private string gameNameField;

        private string gameLinkField;

        private string gameIconField;

        private string gameLogoField;

        private string gameLogoSmallField;

        /// <remarks/>
        public string gameFriendlyName {
            get {
                return this.gameFriendlyNameField;
            }
            set {
                this.gameFriendlyNameField = value;
            }
        }

        /// <remarks/>
        public string gameName {
            get {
                return this.gameNameField;
            }
            set {
                this.gameNameField = value;
            }
        }

        /// <remarks/>
        public string gameLink {
            get {
                return this.gameLinkField;
            }
            set {
                this.gameLinkField = value;
            }
        }

        /// <remarks/>
        public string gameIcon {
            get {
                return this.gameIconField;
            }
            set {
                this.gameIconField = value;
            }
        }

        /// <remarks/>
        public string gameLogo {
            get {
                return this.gameLogoField;
            }
            set {
                this.gameLogoField = value;
            }
        }

        /// <remarks/>
        public string gameLogoSmall {
            get {
                return this.gameLogoSmallField;
            }
            set {
                this.gameLogoSmallField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class playerstatsPlayer {

        private ulong steamID64Field;

        private string customURLField;

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
        public string customURL {
            get {
                return this.customURLField;
            }
            set {
                this.customURLField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class playerstatsStats {

        private decimal hoursPlayedField;

        /// <remarks/>
        public decimal hoursPlayed {
            get {
                return this.hoursPlayedField;
            }
            set {
                this.hoursPlayedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class playerstatsAchievement {

        private string iconClosedField;

        private string iconOpenField;

        private string nameField;

        private string apinameField;

        private string descriptionField;

        private uint unlockTimestampField;

        private bool unlockTimestampFieldSpecified;

        private bool closedField;

        /// <remarks/>
        public string iconClosed {
            get {
                return this.iconClosedField;
            }
            set {
                this.iconClosedField = value;
            }
        }

        /// <remarks/>
        public string iconOpen {
            get {
                return this.iconOpenField;
            }
            set {
                this.iconOpenField = value;
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
        public string apiname {
            get {
                return this.apinameField;
            }
            set {
                this.apinameField = value;
            }
        }

        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public uint unlockTimestamp {
            get {
                return this.unlockTimestampField;
            }
            set {
                this.unlockTimestampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool unlockTimestampSpecified {
            get {
                return this.unlockTimestampFieldSpecified;
            }
            set {
                this.unlockTimestampFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool closed {
            get {
                return this.closedField;
            }
            set {
                this.closedField = value;
            }
        }
    }


}

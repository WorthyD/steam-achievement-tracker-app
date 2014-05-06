using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Models {
    public class Profile {

        public profile PlayerProfile { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class profile {

            private ulong steamID64Field;

            private string steamIDField;

            private string onlineStateField;

            private string stateMessageField;

            private string privacyStateField;

            private byte visibilityStateField;

            private string avatarIconField;

            private string avatarMediumField;

            private string avatarFullField;

            private byte vacBannedField;

            private string tradeBanStateField;

            private byte isLimitedAccountField;

            private string customURLField;

            private string memberSinceField;

            private object steamRatingField;

            private decimal hoursPlayed2WkField;

            private string headlineField;

            private string locationField;

            private string realnameField;

            private string summaryField;

            private profileMostPlayedGame[] mostPlayedGamesField;

            private profileGroup[] groupsField;

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
            public string onlineState {
                get {
                    return this.onlineStateField;
                }
                set {
                    this.onlineStateField = value;
                }
            }

            /// <remarks/>
            public string stateMessage {
                get {
                    return this.stateMessageField;
                }
                set {
                    this.stateMessageField = value;
                }
            }

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
            public string avatarIcon {
                get {
                    return this.avatarIconField;
                }
                set {
                    this.avatarIconField = value;
                }
            }

            /// <remarks/>
            public string avatarMedium {
                get {
                    return this.avatarMediumField;
                }
                set {
                    this.avatarMediumField = value;
                }
            }

            /// <remarks/>
            public string avatarFull {
                get {
                    return this.avatarFullField;
                }
                set {
                    this.avatarFullField = value;
                }
            }

            /// <remarks/>
            public byte vacBanned {
                get {
                    return this.vacBannedField;
                }
                set {
                    this.vacBannedField = value;
                }
            }

            /// <remarks/>
            public string tradeBanState {
                get {
                    return this.tradeBanStateField;
                }
                set {
                    this.tradeBanStateField = value;
                }
            }

            /// <remarks/>
            public byte isLimitedAccount {
                get {
                    return this.isLimitedAccountField;
                }
                set {
                    this.isLimitedAccountField = value;
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

            /// <remarks/>
            public string memberSince {
                get {
                    return this.memberSinceField;
                }
                set {
                    this.memberSinceField = value;
                }
            }

            /// <remarks/>
            public object steamRating {
                get {
                    return this.steamRatingField;
                }
                set {
                    this.steamRatingField = value;
                }
            }

            /// <remarks/>
            public decimal hoursPlayed2Wk {
                get {
                    return this.hoursPlayed2WkField;
                }
                set {
                    this.hoursPlayed2WkField = value;
                }
            }

            /// <remarks/>
            public string headline {
                get {
                    return this.headlineField;
                }
                set {
                    this.headlineField = value;
                }
            }

            /// <remarks/>
            public string location {
                get {
                    return this.locationField;
                }
                set {
                    this.locationField = value;
                }
            }

            /// <remarks/>
            public string realname {
                get {
                    return this.realnameField;
                }
                set {
                    this.realnameField = value;
                }
            }

            /// <remarks/>
            public string summary {
                get {
                    return this.summaryField;
                }
                set {
                    this.summaryField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("mostPlayedGame", IsNullable = false)]
            public profileMostPlayedGame[] mostPlayedGames {
                get {
                    return this.mostPlayedGamesField;
                }
                set {
                    this.mostPlayedGamesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("group", IsNullable = false)]
            public profileGroup[] groups {
                get {
                    return this.groupsField;
                }
                set {
                    this.groupsField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class profileMostPlayedGame {

            private string gameNameField;

            private string gameLinkField;

            private string gameIconField;

            private string gameLogoField;

            private string gameLogoSmallField;

            private decimal hoursPlayedField;

            private decimal hoursOnRecordField;

            private string statsNameField;

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

            /// <remarks/>
            public decimal hoursPlayed {
                get {
                    return this.hoursPlayedField;
                }
                set {
                    this.hoursPlayedField = value;
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
            public string statsName {
                get {
                    return this.statsNameField;
                }
                set {
                    this.statsNameField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class profileGroup {

            private ulong groupID64Field;

            private string groupNameField;

            private string groupURLField;

            private string headlineField;

            private string summaryField;

            private string avatarIconField;

            private string avatarMediumField;

            private string avatarFullField;

            private ushort memberCountField;

            private bool memberCountFieldSpecified;

            private byte membersInChatField;

            private bool membersInChatFieldSpecified;

            private ushort membersInGameField;

            private bool membersInGameFieldSpecified;

            private ushort membersOnlineField;

            private bool membersOnlineFieldSpecified;

            private byte isPrimaryField;

            /// <remarks/>
            public ulong groupID64 {
                get {
                    return this.groupID64Field;
                }
                set {
                    this.groupID64Field = value;
                }
            }

            /// <remarks/>
            public string groupName {
                get {
                    return this.groupNameField;
                }
                set {
                    this.groupNameField = value;
                }
            }

            /// <remarks/>
            public string groupURL {
                get {
                    return this.groupURLField;
                }
                set {
                    this.groupURLField = value;
                }
            }

            /// <remarks/>
            public string headline {
                get {
                    return this.headlineField;
                }
                set {
                    this.headlineField = value;
                }
            }

            /// <remarks/>
            public string summary {
                get {
                    return this.summaryField;
                }
                set {
                    this.summaryField = value;
                }
            }

            /// <remarks/>
            public string avatarIcon {
                get {
                    return this.avatarIconField;
                }
                set {
                    this.avatarIconField = value;
                }
            }

            /// <remarks/>
            public string avatarMedium {
                get {
                    return this.avatarMediumField;
                }
                set {
                    this.avatarMediumField = value;
                }
            }

            /// <remarks/>
            public string avatarFull {
                get {
                    return this.avatarFullField;
                }
                set {
                    this.avatarFullField = value;
                }
            }

            /// <remarks/>
            public ushort memberCount {
                get {
                    return this.memberCountField;
                }
                set {
                    this.memberCountField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool memberCountSpecified {
                get {
                    return this.memberCountFieldSpecified;
                }
                set {
                    this.memberCountFieldSpecified = value;
                }
            }

            /// <remarks/>
            public byte membersInChat {
                get {
                    return this.membersInChatField;
                }
                set {
                    this.membersInChatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool membersInChatSpecified {
                get {
                    return this.membersInChatFieldSpecified;
                }
                set {
                    this.membersInChatFieldSpecified = value;
                }
            }

            /// <remarks/>
            public ushort membersInGame {
                get {
                    return this.membersInGameField;
                }
                set {
                    this.membersInGameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool membersInGameSpecified {
                get {
                    return this.membersInGameFieldSpecified;
                }
                set {
                    this.membersInGameFieldSpecified = value;
                }
            }

            /// <remarks/>
            public ushort membersOnline {
                get {
                    return this.membersOnlineField;
                }
                set {
                    this.membersOnlineField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool membersOnlineSpecified {
                get {
                    return this.membersOnlineFieldSpecified;
                }
                set {
                    this.membersOnlineFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte isPrimary {
                get {
                    return this.isPrimaryField;
                }
                set {
                    this.isPrimaryField = value;
                }
            }
        }


    }
}

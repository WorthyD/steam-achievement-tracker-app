using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.DesignData.Model
{
    public class Game : IGame
    {
        public long SteamUserID
        {
            get;
            set;

        }

        public int AppID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string StatsLink
        {
            get;
            set;
        }

        public string GameLink
        {
            get;
            set;
        }

        public string Logo
        {
            get;
            set;
        }

        public decimal HoursPlayed
        {
            get;
            set;
        }

        public decimal RecentHours
        {
            get;
            set;
        }
        public string RecentHoursFormatted
        {
            get
            {
                return string.Format("{0} hrs", this.RecentHours);
            }
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }

        public DateTime AchievementRefresh
        {
            get;
            set;
        }

        public int AchievementsEarned
        {
            get;
            set;
        }

        public int TotalAchievements
        {
            get;
            set;
        }
        public double PercentComplete
        {
            get
            {
                return ((double)AchievementsEarned / (double)TotalAchievements * 100);
            }
        }


        public string PercentCompleteFormatted
        {
            get
            {
                return string.Format("{0}%", (((decimal)AchievementsEarned / (decimal)TotalAchievements) * 100));
            }
        }

        public string ProgressText
        {
            get
            {
                return string.Format("{0} of {1}", AchievementsEarned, TotalAchievements);
            }
        }

        public Game()
        {
            var rnd = new Random();
            this.PopulateDesignData("test", rnd);
        }

        public void PopulateDesignData(string name, Random rnd)
        {
            int ticks = rnd.Next(0, 100);
            this.Name = name;
            this.Logo = GetRandomImage();
            this.RecentHours = ticks;

            this.AchievementsEarned = ticks;
            this.TotalAchievements = 100;

        }

        private string GetRandomImage()
        {
            List<string> logos = new List<string>() { 
         "http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/285160/4e0add73085939dff818bdc506437560feacfd91.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/259740/ee4b3ec3df1fb0b0d4cc7f63676fd717ac8d76c6.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/201040/7cc1db092002076e7dcd29104e242c8c741022ab.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/241320/740a4a472d90c0e32dfbdfb961122a560b372f62.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/98200/3b20447980b019783a4e37893660d1ce54893699.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/96100/1533e9bf83bfd47553791f9b60500d33e8364d38.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/239450/858d5de04891402916627b2497610f3b5dcf9590.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/72850/c5af3cde13610fca25cd17634a96d72487d21e74.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/284870/1b6c92bec749530947b917c756e37f23d8c5777c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/227580/a35eae6b3114e3030be3155118b229a38600ff2d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/284710/c9bc63f16e87111d0295c62c2b9e57b4d6656d73.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/108710/0f9b6613ac50bf42639ed6a2e16e9b78e846ef0a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/202750/d3593fa14e4ea8685dc6b1f71dbaa980c013ff02.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/34010/3ea9dae28f71c9535229dc23a594734497307fa9.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/57300/75b8a82acfb05abda97977ac4eb5af20e0dcf01e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/91200/9b71353b7e93eb3c82ca5f35d4d7241c8f545a07.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/219890/23966982a5795854342af3522706c7f9c6a83cb5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/112100/26f6cd7f9574c8a14b454ed9a927b511e3435925.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/207650/d6491d7919f9da534d1695e6cde5c69fc5f0ec0c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/204300/a2eba6157703c60bfcc199f06df5f1568c9835bb.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/107100/d113d66ef88069d7d35a74cfaf2e2ee917f61133.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/35140/172e0928b845c18491f1a8fee0dafe7a146ac129.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/200260/9b229e12fd5ce27bd101d5862c19b1a6e3d01239.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/238460/13380473acaa95f843301b8a21a383790ae384de.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/231040/5fc23f952e6372c504237656a1d73a2503cdfb01.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/78000/7c4e103ce278e3bc50d7e7b33c4ddb8196f88817.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/203750/101cf86ad6b8d8ce6328c373d23b0b09318b5a1f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/7670/4c2a7f97e6556a95319eb346aed7beff9fe0535c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8850/fde6fa1b15e4eb409c9d592197024571fded77e7.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8870/870bb889e192cf8d31876ed04d329a5d51c6fc2c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214933/68c13c182f55c1e077b3c51278df6453c1924d09.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214931/ff14ef6177834ecdf3efc59dbd7145012cb21da5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214932/cd783570d5b90bec674e0db9bd7c80a43dee42d0.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/63700/86e3cdec2b272f630385b89c7b2bba3ff422c421.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/80350/5d71708784dbd3feaaeba49cdc0793a76570ca86.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/80360/b0f86e0c07747849d380430cb8381e4c0edd75ca.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/80340/5aed3f0772a29999f2f16402fca87139c23053ec.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3370/1369f5d7426f2b5bed900e8693393d1e2b631b98.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8980/88ec298ff1ff0d748df39e084892aed6e919b146.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/49520/86b0fa5ddb41b4dfff7df194a017f3418130d668.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/245890/a98ccfdfce3f9caa26b7c8221e4117318cc07ec0.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/245910/4e284ec333c4d13457578a20d677240c82f0ff39.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/245930/78bd983dc6ceef403e8c4c647c711b4683ab8565.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/245950/9ee951fa900282d583dab7d20f22bae90f3aae27.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/65920/ceee419f7abfd5f5292e3c3ebe169b7ec8c66dfd.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/40940/41634cff9cec43edb667f066eae8e9d41d3d3d12.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/50110/1e78d18afd61ba948ebb5c2c6112c723fdff6ecb.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8990/b4b4b1e093cd60d2bfa77155ab64197f8c792453.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/26800/dc76bb847fbb82ca81e122927541398d41638ac8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/266130/d32361035e143a77f30581c5fc9417ab4ec89035.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/250460/39853c8a79229e95e95d8599012d0a9d819d5850.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/33600/31ea8ee398fb2a53ca51bde0ffa882e8096d329a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/225080/12f5c3aaa2b1d69d0786e1d09e0b77e2da6f8980.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/225260/cc8b60ac1fa649c950ff7a9881b98709b8372f94.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/24740/196d5d0945d6c608a621cf7d44429644ebeae267.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/95300/4ed97f9c05ae4e0351dd5191f907adf5ddb1d356.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/204360/793216ec14c639bdaf2f0119c8cc408b8e9ad7b1.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/200900/a242e0465a65ffafbf75eeb521812fb575990a33.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/282760/7a108f4a205f48460723966b9ac482206a05cb21.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/72000/6e01635915c7a052c64c81f1408844a596917d2e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/26500/db01e5e8973e4a9590f1423b9c7c2199d7cb0186.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/4560/e12e8695c6766b47a089351dd9c4531e669c2a7b.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/228200/87aa009e93d5aa56a55d0e9056708d018ddd6483.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/115100/125ad90dba2c6c3726837ae9c1889d8009f806a9.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/730/d0595ff02f5c79fd19b06f4d6165c3fda2372820.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/108800/bee338e11932e97e995b6e2d84d0772f7b22f2a9.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/107310/c21721fb881d5548bd9e9693d9c35d41f2565715.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/17470/01400b8d7847c309e5d47d7ceb3f885f47247501.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/203810/39f2f2baf454fabdd8a6161e9353ebd9ee335ed2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214340/12ea414ebaaed18950a4454fd770065bc1cef38e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/70000/2c6bf7cf502511afe182edcc2b2d62d5a8eb4796.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/205100/b94f5ff693304b7f70f88403d444686c4af3b940.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/230050/0dfb5f55501d52def13dea3a2987eee8781a5d7c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/208200/e5a209be19bf207fc9950ab03bde98cc736475d6.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/570/d4f836839254be08d8e9dd333ecc9a01782c26d2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/248650/3d14c0f48d7a9b2f78302e7ae884060099fa18e3.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/219200/20cabef5c38c8e4e075ee002894c9ef4920a5580.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/57900/a8d1246ad6962f0bfe9f59b1a314fcf53e712fd3.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/65800/71af270cff61ab197f9932212012134a436d9682.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/236090/544fd60b00696d8c3402828da7055fea64d619ca.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/65300/4290e1264b6c0dae04a41b4def85204d29ebecf2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/38740/9c86ad3f647def777dc7072d72f4081b006b4844.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/6100/b7b60c57fe252f74272beb2b700c7511462f288f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214550/d9c64980c302b2f4d7d62228041bef3e315a644d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/235820/d98036a017a361089f9589f44c1fcbdc834248ce.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/207570/eb960b8e42669cdf36b19536230a5ffbdea0b96f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/284770/2e479636d41d25acb5090f33bde3734d9ad3c16f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3600/d3a6c4ac8f25fe2dd823c7442b5e19b867e8de8a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/266330/2c4c14449e11d337e9ff351be1706f41492eca0d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/263820/4229cdb8b45174c80d1abbe2df37ea03eba0c46b.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/233470/3432d5d501ca6cf01eebb98a43d927537d42134e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/22370/ddccc41c513694e7a5542aa115e9e091d6495420.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/22380/1a52975c043227184162627285e4bc0c83216e02.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/22470/98fabcc80330e5b79fe6958f6ead614d36bf73d6.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/72730/121efee43bc1655f230e24d30c803ec24e9bdbff.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/72740/1f6ae8414c36a5cf8a89299f95786316255e0904.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3390/c516eb69b60d3987b0bb2ffb39a006a6be0953ba.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/224760/d2789dc5fb6bfee4d07cd3ec06985593fffd606c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/209690/0261c53f4b143b7e6b3b214f631dee9e93fc34b0.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/215710/a40127479fd3fe50fe9fbf7ff014c7ad3ce20df5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/259600/8af36a2ecf5a7bfe2c5e921b9a938759ab964f95.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/267660/7ead5729346d3d83ee5aa76b497d32a3dcb93a82.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/245550/98defd2daedb3910583439bffb12e0baeb20ff6c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/212680/975193db5ca8cc2a4c969cea8f80d93157264ec1.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/44200/664563d2b8c2d2fb66d8ab183d8689eb58073274.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/223220/9c8baddbab7938b5b995843d36526a30bd12bb1d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/265930/f116260f6858dda8a2e4c0ccedf270c8a24a0add.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8660/bec45b45a4fdc8c517131fa78d9b502539347bd4.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214770/461f1e9e34cf80edf3581d78c5d24e20501eeaf2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/70/6bd76ff700a8c7a5460fbae3cf60cb930279897d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/220/e4ad9cf1b7dc8475c1118625daf9abd4bdcbcad0.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/320/6dd9f66771300f2252d411e50739a1ceae9e5b30.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/380/b5a666a961d8b39896887abbed3b78c2b837c238.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/420/553e6a2e7a469dcbaada729baa1f5fd7764668df.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/340/867cce5c4f37d5ed4aeffb57c60e220ddffe4134.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/130/927d38e83e3e4ca218a0fc7b32515eeb99aa8ff7.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/50/bb696ddfd8f8ef0892d5f2154d8617528d3cc2ec.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/280/a612dd944b768e55389140298dcfda2165db8ced.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/360/9a5b7119d4e8977fffcd370d3c24036be7cee904.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/277430/5b8a0774b816b0edeaac1cbf2deeaec26dd486a8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/205230/bfc378307d9dacbf03abf6c0b6e846654d9d270b.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/219150/540a1457099f072ced7153239861e42f14febd56.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/207080/f2c3f3e7104ad6d8719c2698406c79efe6de41e7.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214970/4559f77d2875c60562bebb22f656de6824badc6e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/246420/4a30b9d0a8b6e7287f2b617dd28dce6910aeafe8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/102500/6d4f2d6a95423ee4b43d217d1e089fd9112f7ae7.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/231740/988728706a0259a446141134a2788d3892a11a0f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/500/0f67ee504d8f04ecd83986dd7855821dc21f7a78.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/550/205863cc21e751a576d6fff851984b3170684142.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/207170/5898cd32c949e03f95a5333c2399508b1a95aa4a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214510/45d52bbba9c5882f68e0fa288aeada7eef957b18.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/249130/8b012ffdf2cb13e6f71cdf3606ce053c888ff3b5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/48000/9f35c3d64649a5a03b69d6a9218b1f77caf15025.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/221260/832ef3fdc5f9f38113302042f0c639ec9668ab73.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/209830/14171f54fd558e9ae53c19018b9f5d67465bad21.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/269270/acb754c3f60e662407ce8415dfb2b33e7c9b47fe.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214560/c20501309696e5bcda98e9e4f2649abc5720a1d1.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/268240/4759153de17710d4e11952fdbc313e3cdff83fc5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/47830/8a925ea4d40df32587ddae98d4e7fc5a6518b0f7.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/47790/8a925ea4d40df32587ddae98d4e7fc5a6518b0f7.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/47799/61ed1e3eefb0881e84f678623e2ce7ffc62aa27f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/4700/fcd1abd6380998e473b92690e28a9fe0a1a27b8d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/250180/885f8184221d56282a66da2f70fd3fc46a5eb363.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/17410/8c5a900802fabf20a7922c6a69cec9320c940514.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/113020/60642017342ab7f3c924ee9d13b99702a50e5d9e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/247370/38b18142083a48c59041480b0ee86888423146f8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/284790/943c363f655c7aa8f242856c0afc499d9adf481d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/11330/5573953b12147e1ca04f793634247e63d7c6f0d2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/211360/109f59a841a271e4f97175c0ef56ce6809d93fdc.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/200390/ec58f4b09ffbe30810e511ea6d609ae2c3dd96c8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/266210/da51cd7a26789ecea262b662d0cd699548c14593.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/18000/bb921dc09cd79ecd50b5320415c685b10b78f08a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/18020/cc85e91c40d416fdb9ccd050e340624e2a4928fc.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/104900/5d06e83688878ae101742c083d45264866b0f918.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/29180/d14a2097cad1a45fdb6eca2c22cc31d8dd133705.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/239030/eb4c045f73f9a4b1bac708e70fb12f12cd53010f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/250580/e05c4409a8809958868a3028f6314b7011008a49.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/218620/4467a70648f49a6b309b41b81b4531f9a20ed99d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3480/ddc060ce453b7cfa8c82ba2abc321e1b6110fd4e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3540/4b7bcc68dfc5faf786565132e9e28340061e949a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/213030/39cd6d3c7215fee336740655bf0e4fd74c5070ec.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/237570/c66da3f8285197c2e222c10064d2d9c434882b58.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3590/85bfe66e921d89b034a3a253fb648f1a930e034a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/234710/0b274bb5ade23104ce267a05ce7ac0f7aaa0248d.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/400/4184d4c0d915bd3a45210667f7b25361352acd8f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/620/d2a1119ddc202fab81d9b87048f495cbd6377502.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/219680/a0db2a8ad167444d7132b405a11c73a57f376ced.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3830/b361ab26b2c47d4abd11be0ebd3d6b675512ec1b.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/80300/36da7ad197249e94f990f855d95d1e79c6324f72.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/33650/c0d84089288ea3a6b255ba197cf22388751d3466.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8600/2b735e9b03a2b5e72ac727a8cac0bc1b95b6027a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/211500/5a9c89c56ea9ac16f4ecd45693a9fe532e3225cb.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/253410/0a1e44b2a896ec320561e3a4d5b30149e9510d74.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/201570/640ec11b1f2242da5bd3359882982e4792778f96.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/236830/ac6571422ba4768dbb8f5196d954872955f26b50.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/286200/16a05aa9ac3edf7de442921f9db28a5463aa6ffd.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/99300/6535ea9cf634e38142113b7c0ede148355f110df.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/222660/9ff2f07fdd3eee05782f2f8dfbe8ea3052cc7c93.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/204630/5d45f7faf840a316f656c8d95cf50415725e0386.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/222730/06920f2db1122c919fcbeeb3c8a88801e965adc8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/93200/68ebad4132877c76e07d9866e4b20f2067ad4942.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/35450/02d367780a6dcdba708bb8b94fbc42f23ba99a5b.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/46560/f965a33e210698d034f42d7ad96c6addbb763977.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/215510/d0efb44cc59152ffaccb850e89b01e4b5e15761a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/241600/c591f688add1e008d5d92e82b9d9fa2332e20491.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/4760/134817933edf4f8d0665d456889c0315c416fff2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/259530/213e390c78ab0e26c5be8b7e91be546b5f4e0b13.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/34270/212f55b3ea1a8c70427890896e93a37b49f57187.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/102840/eec11d103112f36876bd746854d6e8f130ea6078.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/8930/2203f62bd1bdc75c286c13534e50f22e3bd5bb58.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/235580/1aba52debc09567dea8298aa2e0e22ba53d4381f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/228960/3577e5d170f824d7910c7c9c00b3fc7d5afa46a3.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/204220/5e0f448c6fa62e33c8142d2738690b4bc55bed19.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/63380/382d7f4a6eff4896ff4d137f0906735c99bd0300.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/111100/8344f6eeb3fb971ae1574de5aa9efb3234694f84.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/92800/5ffbf030cd3e3af293e0509df7be6f9b2a159ca8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/11240/4b6b0dba7a1dc4cf0529d8f949e598894d0b08a0.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/239350/1a3ce75a075da21471d4d376681b6a8dd2c4a8bd.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/210170/f1d5f3a373420b9645f9cd6da5acd5292639c8eb.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/115110/5bbd716992eab33cc5bbcd54cf691da700372329.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/230980/6e994ba327e66663cc25585d7225cd0109d5c7e3.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/204060/b522ef5ae83648bef02bd3303801aed881d17761.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/224820/cc0f1c2d98dc906aad66792c60e739071b9d509f.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/40800/70f084857297d5fdd96d019db3a990d6d9ec64f1.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/238530/f4c91a9c23963c463dc11a24c16938e4011e568e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/233720/2a0d51aa92d2bf2e168e090f9b72bf60d78fa53e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/233700/f410170426561ce2af3a21bb133b7b6ff75aa4dc.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/63500/0e5a29f1eed738fbcba95b773a596e50bba6c768.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/252310/afe7c5bf5ba84c8a95f19e41e925a71660ecd5d0.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/207750/fbb6eb900a4c8b83d6fbf21245104ac44f6232ec.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/19200/b60a30213e97fc3fd2f6c69f5780b11ab471707e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/07385eb55b5ba974aebbe74d3c99626bda7920b8.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/20/515bc393c861d91b9165f0697040c015f50bcb5e.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/105600/e3f375e78ada9d2ec7ffa521fe1b0052d1d2bbb5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/249590/9f5866823d854ecfb37e5fd6718bfa2a65b871bb.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/214790/e1a86d61e73936e1e279843c781e914302f03a5c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/113200/d9a7ee7e07dffed1700cb8b3b9482105b88cc5b5.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/80330/0db7143de029505740c2aa25187de99c0c6d96bb.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/203830/2c255278bbd5c10771a8760cfd8f3ce08a595300.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/67370/349189b0ac9570679227cb1bd2c742bec12bf97a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/267530/4a57c3cd0e5b4c9a3c6fef681bc80a2486bec780.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/252370/17ccbc5fecbd6bae244ccaea8b2534bafee9a283.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/231160/11e08b7b00d8a24a1f83dec3e7c2ca08e98be78a.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/246580/f3f57e1059d2e5e7dd5460a6f7bc6be95ab55c21.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/220780/b2194d8b207193e0e3d8ae2bc47a91685c577750.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/205910/ca0fe3057ac0310df1e1ab290a290a8a2bc19ff9.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/203210/fdee9104411ecaa69520bacd3efc8130c3ceb7fe.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/41500/e36226c6a0575e6e1838e1f915e91f8b31ab3008.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/200710/fd37abb86628ff54ed304f75c2fb7cf75a4f6902.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/35700/b4cc556db2d1101effb23e576aaeeb3b799157c6.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/35720/7d7c3b93bd85ad1db2a07f6cca01a767069c6407.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/57690/9123d91a47399baf116c2949dcebcd42b1962fbe.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/258890/9932ad807beac236c3af3ff151cb782c6b9ba60b.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/219190/0bb4781ceea94f45a4fd29d3704ac6aa797ad630.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/1510/80982651e79b8556f04e0c0012e65f7c9b6850f2.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/70300/3d362d64d51ce524f12c853290ca6cce5761ff1c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/266170/b4d7e0cadede8230d5fa9d8c7dbad09be72007ec.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/22000/d2a60cb23c6743862af40267817099b08602ee92.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/223810/f35de56358c405b85bee757d0ff0990aed8714a3.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/223870/1ad3b3fa7a4842a83c042e92bd9e4f5f468908de.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/61600/bde7fad7a2427df529dc7ec34dca9520444afb6c.jpg",
"http://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/3620/bf8864417bd820b89db8b025aef85611dc3b8b5d.jpg"


            };

            return logos.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

        }
    }
}

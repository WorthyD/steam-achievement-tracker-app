using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.ViewModel
{
    public class HelpViewModel
    {
        /// <summary> 
        /// Gets the content. 
        /// </summary> 
        /// 
        //https://code.msdn.microsoft.com/windowsapps/Youtube-Sample-df7d1d26/sourcecode?fileId=72331&pathId=371539120
        //  YoutubeItems.Add(new YoutubeItem { Width = 560, Height = 315, FrameBorder = 0, Source = "http://www.youtube.com/embed/avn7Fxcjoxg" }); 
        
        public string Content
        {
            get
            {
                return "";
                    //string.Format(
                    //    @"<iframe width='{0}' height='{1}' src='{2}' frameborder='{3}'></iframe>",
                    //    this.Width,
                    //    this.Height,
                    //    this.Source,
                    //    this.FrameBorder);
            }
        } 
    }
}

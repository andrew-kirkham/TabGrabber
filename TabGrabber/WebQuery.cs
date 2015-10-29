using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace TabGrabber {
    public static class WebQuery {

        public static bool CheckForTab(Song songToLookFor) {
            StringBuilder s = new StringBuilder();
            s.Append(@"http://www.911tabs.com/rss/");
            s.Append(songToLookFor.Artist[0]); //rss feed is alphabetized
            s.Append("/");
            s.Append(songToLookFor.Artist);
            s.Append("/rss.xml");
            try {
                var r = XmlReader.Create(s.ToString());
                var feed = SyndicationFeed.Load(r);
                r.Close();
                return feed.Items.Any(item => item.Title.Text.Equals(songToLookFor.Title + " tabs", StringComparison.CurrentCultureIgnoreCase));
            }
            catch (WebException) {
                //xml feed returned a 404 or 500 error
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TabGrabber {
    public class Song {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        private int Number { get; set; }

        public Song(string Title, string Artist, string Album) {
            parseTitle(Title);
            this.Artist = Artist;
            this.Album = Album;
        }

        private void parseTitle(string title) {
            Regex trackNumberRegex = new Regex(@"^(\d{1,3} )"); //song begins with numbers and a space such as "01 First Track"
            Regex cdAndTrackNumberRegex = new Regex(@"^(\d-\d{1,3} )"); //song begins with cd and track numbers
            if (trackNumberRegex.IsMatch(title)) {
                var substrings = trackNumberRegex.Split(title);
                Title = substrings.Last(); //split the title into just "First Track"
                Number = int.Parse(substrings[1]);
            }
            else if (cdAndTrackNumberRegex.IsMatch(title)) {
                var substrings = cdAndTrackNumberRegex.Split(title);
                Title = substrings.Last(); //split the title into just "First Track"
                var cdAndTrackNumber = substrings[1];
                var trackNumber = cdAndTrackNumber.Split('-').Last();
                Number = int.Parse(trackNumber);
            }
            else {
                Title = title;
            }
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            Song s = obj as Song;
            if (s == null) return false;
            if (s.Title != Title) return false;
            if (s.Album != Album) return false;
            if (s.Artist != Artist) return false;
            return true;
        }
    }
}
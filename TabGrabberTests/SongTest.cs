using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabGrabber;

namespace TabGrabberTests {
    [TestClass]
    public class SongTest {

        private const string TITLE = "Title";
        private const string TRACK_TITLE = "01 Title";
        private const string CD_TRACK_TITLE = "1-01 Title";
        private const string ARTIST = "Artist";
        private const string ALBUM = "Album";

        [TestMethod]
        public void NormalSongTitleTest() {
            Song actual = new Song(TITLE, ARTIST, ALBUM);
            Assert.AreEqual(TITLE, actual.Title);
            Assert.AreEqual(ARTIST, actual.Artist);
            Assert.AreEqual(ALBUM, actual.Album);
        }

        [TestMethod]
        public void TrackTitleTest() {
            Song actual = new Song(TRACK_TITLE, ARTIST, ALBUM);
            Assert.AreEqual(TITLE, actual.Title);
            Assert.AreEqual(ARTIST, actual.Artist);
            Assert.AreEqual(ALBUM, actual.Album);
        }

        [TestMethod]
        public void CdTrackTitleTest() {
            Song actual = new Song(CD_TRACK_TITLE, ARTIST, ALBUM);
            Assert.AreEqual(TITLE, actual.Title);
            Assert.AreEqual(ARTIST, actual.Artist);
            Assert.AreEqual(ALBUM, actual.Album);
        }
    }
}

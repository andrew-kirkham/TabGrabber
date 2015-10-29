using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabGrabber;

namespace TabGrabberTests {
    [TestClass]
    public class LibraryTest {
        private const string ONE_ALBUM_ARTIST_PATH = @"F:\iTunes\iTunes Media\Music\Andrew W.K_";
        private const string SINGLE_ALBUM_PATH = @"F:\iTunes\iTunes Media\Music\Exodus\Tempo of the Damned";
        private const string MULTI_ALBUM_ARTIST_PATH = @"F:\iTunes\iTunes Media\Music\Havok";
        private const string SPECIAL_CHARACTER_ALBUM_PATH = @"F:\iTunes\iTunes Media\Music\Korpiklaani\Karkelo";

        [TestMethod]
        public void LoadArtistOneAlbumTest() {
            var artistSongs = Library.LoadArtistSongs(ONE_ALBUM_ARTIST_PATH);
            Assert.AreEqual(12, artistSongs.Count());
            Assert.IsTrue(artistSongs.Contains(new Song(Title: "Party Hard", Artist: "Andrew W.K_", Album: "I Get Wet")));
        }

        [TestMethod]
        public void LoadArtistTMultipleAlbumsTest() {
            var artistSongs = Library.LoadArtistSongs(MULTI_ALBUM_ARTIST_PATH);
            Assert.AreEqual(32, artistSongs.Count());
            Assert.IsTrue(artistSongs.Contains(new Song(Title: "Wreckquiem", Artist: "Havok", Album: "Burn")));
            Assert.IsTrue(artistSongs.Contains(new Song(Title: "D.O.A.", Artist: "Havok", Album: "Time Is Up")));
            Assert.IsTrue(artistSongs.Contains(new Song(Title: "I Am The State", Artist: "Havok", Album: "Unnatural Selection")));
        }

        [TestMethod]
        public void LoadAlbumTest() {
            var albumSongs = Library.LoadAlbumSongs(SINGLE_ALBUM_PATH);
            Assert.AreEqual(10, albumSongs.Count());
            Assert.IsTrue(albumSongs.Contains(new Song(Title: "Blacklist", Artist: "Exodus", Album: "Tempo of the Damned")));
        }

        [TestMethod]
        public void LoadAlbumSpecialCharactersTest() {
            var albumSongs = Library.LoadAlbumSongs(SPECIAL_CHARACTER_ALBUM_PATH);
            Assert.AreEqual(12, albumSongs.Count());
            Assert.IsTrue(albumSongs.Contains(new Song(Title: "Erämaan Ärjyt", Artist: "Korpiklaani", Album: "Karkelo")));
        }
    }
}
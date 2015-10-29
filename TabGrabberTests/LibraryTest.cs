using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabGrabber;

namespace TabGrabberTests {
    [TestClass]
    public class LibraryTest {
        private const string TEST_ARTIST_PATH = @"F:\iTunes\iTunes Media\Music\Andrew W.K_";
        private const string TEST_ALBUM_PATH = @"F:\iTunes\iTunes Media\Music\Exodus\Tempo of the Damned";

        [TestMethod]
        public void LoadArtistOneAlbumTest() {
            var artistSongs = Library.LoadArtistSongs(TEST_ARTIST_PATH);
            Assert.AreEqual(12, artistSongs.Count());
            Assert.IsTrue(artistSongs.Contains(new Song("Party Hard", "Andrew W.K_", "I Get Wet")));
        }

        [TestMethod]
        public void LoadArtistTMultipleAlbumsTest() {
            var artistSongs = Library.LoadArtistSongs(@"F:\iTunes\iTunes Media\Music\Havok");
            Assert.AreEqual(32, artistSongs.Count());
            Assert.IsTrue(artistSongs.Contains(new Song("Wreckquiem", "Havok", "Burn")));
            Assert.IsTrue(artistSongs.Contains(new Song("D.O.A.", "Havok", "Time Is Up")));
            Assert.IsTrue(artistSongs.Contains(new Song("I Am The State", "Havok", "Unnatural Selection")));
        }

        [TestMethod]
        public void LoadAlbumTest() {
            var albumSongs = Library.LoadAlbumSongs(TEST_ALBUM_PATH);
            Assert.AreEqual(10, albumSongs.Count());
            Assert.IsTrue(albumSongs.Contains(new Song("Blacklist", "Exodus", "Tempo of the Damned")));
        }

        [TestMethod]
        public void LoadAlbumSpecialCharactersTest() {
            var albumSongs = Library.LoadAlbumSongs(@"F:\iTunes\iTunes Media\Music\Korpiklaani\Karkelo");
            Assert.AreEqual(12, albumSongs.Count());
            Assert.IsTrue(albumSongs.Contains(new Song("Erämaan Ärjyt", "Korpiklaani", "Karkelo")));
        }
    }
}
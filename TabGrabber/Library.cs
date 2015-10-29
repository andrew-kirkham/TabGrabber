using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TabGrabber {
    public static class Library {
        public static List<Song> LoadAll(string topLevelDirectory) {
            List<Song> allSongs = new List<Song>();
            foreach (string artistDir in Directory.GetDirectories(topLevelDirectory)) {
                var artistSongs = LoadArtistSongs(artistDir);
                allSongs.AddRange(artistSongs);
            }

            return allSongs;
        }

        public static IEnumerable<Song> LoadArtistSongs(string artistDir) {
            List<Song> artistSongs = new List<Song>();
            foreach (string albumDir in Directory.GetDirectories(artistDir)) {
                var albumSongs = LoadAlbumSongs(albumDir);
                artistSongs.AddRange(albumSongs);
            }
            //incase there are songs with no album directory
            foreach (string song in Directory.GetFiles(artistDir)) {
                Song s = new Song(song, artistDir, "");
                artistSongs.Add(s);
            }
            return artistSongs;
        }

        public static IEnumerable<Song> LoadAlbumSongs(string albumDir) {
            string artistDir = Directory.GetParent(albumDir).Name;
            string albumName = new DirectoryInfo(albumDir).Name;
            List<Song> artistSongs = new List<Song>();
            foreach (string songPath in Directory.GetFiles(albumDir)) {
                var songName = Path.GetFileNameWithoutExtension(songPath);
                Song s = new Song(songName, artistDir, albumName);
                artistSongs.Add(s);
            }
            return artistSongs;
        }
    }
}
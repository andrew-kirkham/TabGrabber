﻿using System.Collections.Generic;
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
            artistSongs.AddRange(Directory.GetFiles(artistDir).Select(song => new Song(song, artistDir, "")));
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

        public static IEnumerable<Song> LazyLoadAll(string libraryPath) {
            return from artistDir in Directory.GetDirectories(libraryPath)
                   from albumDir in Directory.GetDirectories(artistDir)
                   let artistName = Directory.GetParent(albumDir).Name
                   let albumName = new DirectoryInfo(albumDir).Name
                   from songPath in Directory.GetFiles(albumDir)
                   let songName = Path.GetFileNameWithoutExtension(songPath)
                   select new Song(songName, artistName, albumName);
        }
    }
}
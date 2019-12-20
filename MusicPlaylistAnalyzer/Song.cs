using System;
namespace MusicPlaylistAnalyzer
{
    public class Song
    {
        public string name;
        public string artist;
        public string album;
        public string genre;
        public double size;
        public int time;
        public int year;
        public int plays;
        public Song(string name, string artist, string album, string genre, string size, string time, string year, string plays)
        {
            this.name = Convert.ToString(name);
            this.artist = Convert.ToString(artist);
            this.album = Convert.ToString(album);
            this.genre = Convert.ToString(genre);
            this.size = Convert.ToDouble(size);
            this.time = Convert.ToInt32(time);
            this.year = Convert.ToInt32(year);
            this.plays = Convert.ToInt32(plays);
        }
        override public string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", name, artist, album, genre, size, time, year, plays);
        }
    }
}

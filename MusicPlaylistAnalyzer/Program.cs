using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                for (int i = 0; i < args.Length - 1; i++)
                {
                    string file1 = args[i];
                    if (!File.Exists(file1))
                    {
                        Console.WriteLine("{0} does not exist!", file1);
                        System.Environment.Exit(-1);
                    }
                }
                using (var output = File.Create(args[args.Length - 1]))
                {
                }
                int counter = 0;
                string line;
                var data = new List<Song>
                {

                };
                
                System.IO.StreamReader file = new System.IO.StreamReader(args[0]);
                while ((line = file.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        var values = line.Split('\t');
                        if (values.Length != 8)
                        {
                            file.Close();
                            Console.WriteLine("You are missing data on line {0} of your file!", counter + 1);
                            System.Environment.Exit(-1);
                        }
                        data.Add(new Song(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
                    }
                    counter++;
                }

                file.Close();
                string report = "Music Playlist Report\n\n";
                var songsWith200Plays = from song in data where song.plays >= 200 select song;

                report += "Songs with 200 or more plays:\n\n";
                foreach (var song in songsWith200Plays)
                {
                    report += song + "\n";
                }

                report += "\n";
                var songsWithAlternativeGenre = from song in data where song.genre == "Alternative" select song;

                int numAlternative = 0;
                foreach(var song in songsWithAlternativeGenre)
                {
                    numAlternative++;
                }

                string numAlternativeSongs = String.Format("There are {0} songs with a genre of Alternative.", numAlternative);

                report += "Number of Alternative Songs:\n\n";
                report += numAlternativeSongs + "\n\n";

                var songsWithHipHopRapGenre = from song in data where song.genre == "Hip-Hop/Rap" select song;

                int numRap = 0;
                foreach (var song in songsWithHipHopRapGenre)
                {
                    numRap++;
                }

                string numHipHopRapSongs = String.Format("There are {0} songs with a genre of Hip-Hop/Rap.", numRap);

                report += "Number of Hip-Hop/Rap Songs:\n\n";
                report += numHipHopRapSongs + "\n\n";

                var songsFromWelcomeToTheFishbowl = from song in data where song.album == "Welcome to the Fishbowl" select song;

                report += "Songs from Welcome to the Fishbowl:\n\n";

                foreach(var song in songsFromWelcomeToTheFishbowl)
                {
                    report += song + "\n";
                }

                report += "\n";
                var songsBefore1970 = from song in data where song.year < 1970 select song;

                report += "Songs from before 1970:\n\n";
                foreach (var song in songsBefore1970)
                {
                    report += song + "\n";
                }

                report += "\n";
                var songNamesLongerThan85Characters = from song in data where song.name.Length > 85 select song;

                report += "Songs with a name longer than 85 characters:\n\n";
                foreach(var song in songNamesLongerThan85Characters)
                {
                    report += song + "\n";
                }

                report += "\n";
                var longestSong = (from song in data select song).Max(song => song.time);

                var actualLongestSong = from song in data where song.time == longestSong select song;

                report += "Longest Song:\n\n";
                foreach(var song in actualLongestSong)
                {
                    report += song + "\n";
                }
                try
                {
                    System.IO.File.WriteAllText(args[1], report);
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(-1);
                }        
            }
            else
            {
                Console.WriteLine("You did not enter the correct number of arguments!  The correct input is: dotnet MusicPlaylistAnalyzer.dll <PlaylistFile> <ReportFile>.");
            }
        }
    }
    
}

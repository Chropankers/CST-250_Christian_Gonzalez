using System;
using System.Collections.Generic;
using System.IO;

namespace Minesweeper
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string PlayerInitials { get; set; }
        public int DifficultyLevel { get; set; } // 1 for Easy, 2 for Medium, 3 for Hard
        public TimeSpan TimeElapsed { get; set; }
        public double Score { get; private set; }

        public PlayerStats(string playerInitials, int difficultyLevel, TimeSpan timeElapsed)
        {
            PlayerInitials = playerInitials;
            DifficultyLevel = difficultyLevel;
            TimeElapsed = timeElapsed;
            Score = CalculateScore();
        }

        private double CalculateScore()
        {
            // Scoring formula that rewards higher difficulty levels
            return (DifficultyLevel * 1000) / TimeElapsed.TotalSeconds;
        }

        public int CompareTo(PlayerStats other)
        {
            if (other == null) return 1;
            return other.Score.CompareTo(this.Score); // Higher score comes first
        }

        public override string ToString()
        {
            return $"{PlayerInitials} - {TimeElapsed.ToString(@"hh\:mm\:ss")} - {Score:F2}";
        }

        public static void SaveScoresToFile(string filePath, List<PlayerStats> scores)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var score in scores)
                {
                    writer.WriteLine($"{score.PlayerInitials},{score.DifficultyLevel},{score.TimeElapsed.TotalSeconds}");
                }
            }
        }

        public static List<PlayerStats> LoadScoresFromFile(string filePath)
        {
            List<PlayerStats> scores = new List<PlayerStats>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 3 &&
                            double.TryParse(parts[2], out double seconds))
                        {
                            scores.Add(new PlayerStats(parts[0], int.Parse(parts[1]), TimeSpan.FromSeconds(seconds)));
                        }
                    }
                }
            }

            return scores;
        }
    }
}

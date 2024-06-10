using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string PlayerInitials { get; set; }
        public int DifficultyLevel { get; set; } // 1 for Easy, 2 for Medium, 3 for Hard
        public TimeSpan TimeElapsed { get; set; }
        public double Score { get; private set; }

        public PlayerStats(string playerInitials, int difficultyLevel, TimeSpan timeElapsed, bool won)
        {
            PlayerInitials = playerInitials;
            DifficultyLevel = difficultyLevel;
            TimeElapsed = timeElapsed;
            Score = CalculateScore(won);
        }

        public double CalculateScore(bool won)
        {
            const int basePoints = 1000;
            const double timePenaltyFactor = 0.05;
            int difficultyMultiplier = DifficultyLevel;
            const int winBonus = 5000; // Bonus points for winning
            const int lossPenalty = 5000; // Penalty points for losing

            // Exponential decay to penalize longer times more severely
            double timePenalty = Math.Exp(timePenaltyFactor * TimeElapsed.TotalSeconds);

            // Calculate the raw score
            double rawScore = basePoints / timePenalty;

            // Apply the difficulty multiplier
            double finalScore = rawScore * difficultyMultiplier;

            // Apply win bonus or loss penalty
            if (won)
            {
                finalScore += winBonus;
            }
            else
            {
                finalScore -= lossPenalty;
                finalScore = Math.Max(finalScore, 1); // Ensure the score is at least 1
            }

            return finalScore;
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
                    writer.WriteLine($"{score.PlayerInitials},{score.DifficultyLevel},{score.TimeElapsed.TotalSeconds},{score.Score}");
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
                        if (parts.Length == 4 &&
                            double.TryParse(parts[2], out double seconds) &&
                            double.TryParse(parts[3], out double score))
                        {
                            bool won = score > 5000;
                            scores.Add(new PlayerStats(parts[0], int.Parse(parts[1]), TimeSpan.FromSeconds(seconds), won));
                        }
                    }
                }
            }

            return scores;
        }

        // LINQ example: Get top 5 scores
        public static List<PlayerStats> GetTopScores(List<PlayerStats> scores, int topCount)
        {
            return scores.OrderByDescending(s => s.Score).Take(topCount).ToList();
        }

        // LINQ example: Filter scores by difficulty level
        public static List<PlayerStats> FilterScoresByDifficulty(List<PlayerStats> scores, int difficultyLevel)
        {
            return scores.Where(s => s.DifficultyLevel == difficultyLevel).ToList();
        }
    }
}

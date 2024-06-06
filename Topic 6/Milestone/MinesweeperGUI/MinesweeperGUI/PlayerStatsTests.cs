using NUnit.Framework;
using Minesweeper;
using System;
using System.Collections.Generic;
using System.IO;

namespace MinesweeperTests
{
    [TestFixture]
    public class PlayerStatsTests
    {
        [Test]
        public void CalculateScore_CorrectlyCalculatesScore()
        {
            // Arrange
            var playerStats = new PlayerStats("ABC", 3, new TimeSpan(0, 2, 0)); // 2 minutes

            // Act
            double score = playerStats.Score;

            // Assert
            Assert.That(score, Is.EqualTo((3 * 1000) / 120).Within(0.01), "Score calculation is incorrect.");
        }

        [Test]
        public void CompareTo_CorrectlyComparesScores()
        {
            // Arrange
            var player1 = new PlayerStats("ABC", 3, new TimeSpan(0, 2, 0)); // 2 minutes
            var player2 = new PlayerStats("XYZ", 3, new TimeSpan(0, 3, 0)); // 3 minutes

            // Act
            int comparisonResult = player1.CompareTo(player2);

            // Assert
            Assert.That(comparisonResult, Is.EqualTo(1), "Comparison result is incorrect. Player1 should have a higher score.");
        }

        [Test]
        public void SaveAndLoadScores_CorrectlySavesAndLoadsScores()
        {
            // Arrange
            var scores = new List<PlayerStats>
            {
                new PlayerStats("ABC", 1, new TimeSpan(0, 1, 0)),
                new PlayerStats("DEF", 2, new TimeSpan(0, 2, 0)),
                new PlayerStats("GHI", 3, new TimeSpan(0, 3, 0))
            };
            string filePath = "test_scores.txt";

            // Act
            PlayerStats.SaveScoresToFile(filePath, scores);
            var loadedScores = PlayerStats.LoadScoresFromFile(filePath);

            // Assert
            Assert.That(loadedScores.Count, Is.EqualTo(3), "Loaded scores count is incorrect.");
            Assert.That(loadedScores[0].PlayerInitials, Is.EqualTo("ABC"), "First player's initials are incorrect.");
            Assert.That(loadedScores[0].DifficultyLevel, Is.EqualTo(1), "First player's difficulty level is incorrect.");
            Assert.That(loadedScores[0].TimeElapsed, Is.EqualTo(new TimeSpan(0, 1, 0)), "First player's time elapsed is incorrect.");
        }

        [Test]
        public void PlayerStats_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string initials = "XYZ";
            int difficulty = 2;
            TimeSpan timeElapsed = new TimeSpan(0, 5, 0); // 5 minutes

            // Act
            var playerStats = new PlayerStats(initials, difficulty, timeElapsed);

            // Assert
            Assert.That(playerStats.PlayerInitials, Is.EqualTo(initials));
            Assert.That(playerStats.DifficultyLevel, Is.EqualTo(difficulty));
            Assert.That(playerStats.TimeElapsed, Is.EqualTo(timeElapsed));
            Assert.That(playerStats.Score, Is.EqualTo((difficulty * 1000) / timeElapsed.TotalSeconds).Within(0.01));
        }
    }
}

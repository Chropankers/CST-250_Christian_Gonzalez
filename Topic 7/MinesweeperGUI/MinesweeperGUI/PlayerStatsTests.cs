using NUnit.Framework;
using Minesweeper;
using System;

namespace MinesweeperTests
{
    [TestFixture]
    public class PlayerStatsTests
    {
        [Test]
        public void CalculateScore_Win()
        {
            var playerStats = new PlayerStats("ABC", 3, TimeSpan.FromSeconds(120), true);
            double expectedScore = playerStats.CalculateScore(true); // Calculate expected score with win parameter
            Assert.That(playerStats.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void CalculateScore_Lose()
        {
            var playerStats = new PlayerStats("ABC", 3, TimeSpan.FromSeconds(120), false);
            double expectedScore = playerStats.CalculateScore(false); // Calculate expected score with lose parameter
            Assert.That(playerStats.Score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void CompareTo_SameScore()
        {
            var playerStats1 = new PlayerStats("ABC", 3, TimeSpan.FromSeconds(120), true);
            var playerStats2 = new PlayerStats("XYZ", 3, TimeSpan.FromSeconds(120), true);
            Assert.That(playerStats1.CompareTo(playerStats2), Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_HigherScore()
        {
            var playerStats1 = new PlayerStats("ABC", 3, TimeSpan.FromSeconds(120), true);
            var playerStats2 = new PlayerStats("XYZ", 3, TimeSpan.FromSeconds(240), true);
            Assert.That(playerStats1.CompareTo(playerStats2), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_LowerScore()
        {
            var playerStats1 = new PlayerStats("ABC", 3, TimeSpan.FromSeconds(240), true);
            var playerStats2 = new PlayerStats("XYZ", 3, TimeSpan.FromSeconds(120), true);
            Assert.That(playerStats1.CompareTo(playerStats2), Is.LessThan(0));
        }

        [Test]
        public void ToString_FormattedString()
        {
            var playerStats = new PlayerStats("ABC", 3, TimeSpan.FromSeconds(120), true);
            string expectedString = $"ABC - {TimeSpan.FromSeconds(120).ToString(@"hh\:mm\:ss")} - {playerStats.Score:F2}";
            Assert.That(playerStats.ToString(), Is.EqualTo(expectedString));
        }
    }
}

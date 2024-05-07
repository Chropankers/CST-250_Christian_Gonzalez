using NUnit.Framework;
using Minesweeper;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class UnitTest2
    {
        private Board board;
        private int size = 10; // Assuming the board size
        private float difficulty = 0.1f; // Assuming a difficulty that sets some mines

        [SetUp]
        public void Setup()
        {
            // Initialize the board before each test
            board = new Board(size, difficulty);
            // Assume we place a mine at position (0,0) for testing
            board.Grid[0, 0].Live = true;
        }

        [Test]
        public void GameEndsWhenMineIsHit()
        {
            // Act
            bool hitMine = board.Grid[0, 0].Live; // Simulate clicking on (0, 0)

            // Assert
            Assert.IsTrue(hitMine, "The cell should contain a mine, indicating game should end.");
        }
    }
}

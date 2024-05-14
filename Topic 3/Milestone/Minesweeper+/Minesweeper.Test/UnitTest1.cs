using NUnit.Framework;
using Minesweeper;

namespace Minesweeper.Test
{
    public class Tests
    {
        private Board board;
        private int size = 10; // Example size for the board

        [SetUp]
        public void Setup()
        {
            // Initialize the board with the given size and a difficulty that implies a certain number of mines
            board = new Board(size, 0.1f);  // Using a 10% difficulty as an example
        }

        [Test]
        public void Board_CorrectDimensions()
        {
            // Assert
            Assert.AreEqual(size, board.Size, "Board size should match the initialized value.");

            // Optionally, verify the dimensions of the Grid array if needed
            Assert.AreEqual(size, board.Grid.GetLength(0), "Grid row size should match the board size.");
            Assert.AreEqual(size, board.Grid.GetLength(1), "Grid column size should match the board size.");
        }
    }
}

using NUnit.Framework;
using Minesweeper;
// Christian Gonzalez/CST-250/ 5/13/24 This is an original work
namespace Minesweeper.Tests
{
    [TestFixture]
    public class UnitTest3
    {
        private Board board;
        private int size = 10; // Board size
        private float difficulty = 0.1f; // Just a placeholder for simplicity

        [SetUp]
        public void Setup()
        {
            // Initialize the board with a specific setup for testing
            board = new Board(size, difficulty);
            // Manually clear all mines for control in tests
            foreach (var cell in board.Grid)
            {
                cell.Live = false;
            }
            // Setup a specific test case
            // Assume no adjacent mines around (1,1)
            board.Grid[1, 1].Visited = false;
            board.Grid[1, 1].LiveNeighbors = 0;
        }

        [Test]
        public void FloodFill_RevealsAllConnectedEmptyCells()
        {
            // Act
            board.FloodFill(1, 1);  // Start flood fill at (1, 1)

            // Assert
            // Check that all cells around (1, 1) are revealed
            Assert.IsTrue(board.Grid[0, 0].Visited, "Cell (0,0) should be revealed");
            Assert.IsTrue(board.Grid[0, 1].Visited, "Cell (0,1) should be revealed");
            Assert.IsTrue(board.Grid[0, 2].Visited, "Cell (0,2) should be revealed");
            Assert.IsTrue(board.Grid[1, 0].Visited, "Cell (1,0) should be revealed");
            Assert.IsTrue(board.Grid[1, 1].Visited, "Cell (1,1) should be revealed");
            Assert.IsTrue(board.Grid[1, 2].Visited, "Cell (1,2) should be revealed");
            Assert.IsTrue(board.Grid[2, 0].Visited, "Cell (2,0) should be revealed");
            Assert.IsTrue(board.Grid[2, 1].Visited, "Cell (2,1) should be revealed");
            Assert.IsTrue(board.Grid[2, 2].Visited, "Cell (2,2) should be revealed");
        }
    }
}

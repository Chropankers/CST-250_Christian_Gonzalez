//Christian Gonzalez -- CST-250 -- 5/12/24 This is original work, some structural inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
namespace Minesweeper
{
    public class Cell
    {
        // Properties
        public int Row { get; private set; }  // Immutable after initialization
        public int Column { get; private set; }  // Immutable after initialization
        public bool Visited { get; set; } = false;
        private bool live = false;  // Encapsulate access to the 'live' state
        public bool Live
        {
            get => live;
            set
            {
                if (!Visited)  // Prevent changing if the cell has already been visited
                {
                    live = value;
                }
            }
        }
        private int liveNeighbors = 0;  // Encapsulate the count of live neighbors
        public int LiveNeighbors
        {
            get => liveNeighbors;
            set
            {
                if (value >= 0)  // Simple validation to prevent negative counts
                {
                    liveNeighbors = value;
                }
            }
        }

        // Constructor
        public Cell(int row, int column)
        {
            if (row < 0 || column < 0)
            {
                throw new ArgumentException("Row and column indices must be non-negative.");
            }
            Row = row;
            Column = column;
        }
    }
}

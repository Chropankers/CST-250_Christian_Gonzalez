namespace Minesweeper
{
    //Christian Gonzalez -- CST-250 -- 4/28/24 This is original work, some structural inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
    public class Cell
    {
        // Properties
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;  // True if the cell contains a bomb
        public int LiveNeighbors { get; set; } = 0;  // Count of live neighbors

        // Constructor
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        // Additional methods go here later
    }
}

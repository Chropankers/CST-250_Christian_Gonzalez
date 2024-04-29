namespace Models
{
    //Christian Gonzalez -- CST-250 -- 4/28/24 This is original work, some structural inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 10; // Example size
            float difficulty = 0.15f; // Example difficulty (15% of cells are bombs)

            Board board = new Board(boardSize, difficulty);
            board.CalculateLiveNeighbors(); // Set up neighbors after initializing bombs

            PrintBoard(board);
        }

        // Helper method to display the board in the console
        static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // Always display the live neighbor count
                    int displayCount = board.Grid[i, j].LiveNeighbors;
                    if (board.Grid[i, j].Live)
                    {
                        displayCount++;  // Include this cell in the count if it's live
                    }
                    Console.Write($"{displayCount} ");
                }
                Console.WriteLine();
            }
        }


    }
}

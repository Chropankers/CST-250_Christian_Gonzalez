//Christian Gonzalez -- CST-250 -- 5/6/24 This is original work, some structural inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp

using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10; // Size of the board
            float difficulty = 0.1f; // Difficulty determines the number of mines
            Board board = new Board(size, difficulty);
            bool gameOver = false;
            bool success = true;

            while (!gameOver)
            {
                Console.Clear();
                PrintBoardDuringGame(board);
                Console.WriteLine("Enter row and column numbers starting from 0 to 9 (e.g., '4 5'): ");

                int row, col;
                if (!TryReadPosition(out row, out col))
                {
                    Console.WriteLine("Invalid input. Please enter numbers in the format 'row col'. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    Console.WriteLine("Entered coordinates are out of bounds. Please try again. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                if (board.Grid[row, col].Live)
                {
                    gameOver = true;
                    success = false;
                    break; // Ensure the loop breaks immediately when a mine is hit
                }

                board.RevealCell(row, col);
                gameOver = board.CheckWinCondition(); // Check if all non-mine cells have been revealed
            }

            if (success)
            {
                Console.WriteLine("Congratulations! You've cleared the minefield!");
            }
            else
            {
                Console.WriteLine("Boom! You've hit a mine. Game over.");
                PrintBoardDuringGame(board, true); // Show final board with mines
            }
        }
        static bool TryReadPosition(out int row, out int col)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split();
            if (parts.Length == 2 && int.TryParse(parts[0], out row) && int.TryParse(parts[1], out col))
            {
                return true;
            }
            row = -1;
            col = -1;
            return false;
        }
        public static void PrintBoardDuringGame(Board board, bool revealMines = false)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Cell cell = board.Grid[i, j];
                    if (!cell.Visited && revealMines && cell.Live)
                    {
                        Console.Write("* ");  // Display mines at the end of the game if the player lost
                    }
                    else if (!cell.Visited)
                    {
                        Console.Write("? ");
                    }
                    else if (cell.LiveNeighbors > 0)
                    {
                        Console.Write($"{cell.LiveNeighbors} ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}



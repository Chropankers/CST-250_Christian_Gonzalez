using System;
// Christian Gonzalez/CST-250/ 5/13/24 This is a work based upon the Activity x Assignment for Programming in C# II, Grand Canyon University as well as the following:
// https://stackoverflow.com/questions/20783702/knights-tour-backtracking-lasts-too-long
namespace KnightsTour
{
    class Program
    {
        static int BoardSize = 8;
        static int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };
        static int[,] boardGrid = new int[BoardSize, BoardSize];

        public static void Main()
        {
            SolveKT();
            Console.ReadLine();
        }

        // Main function that solves the Knight's Tour problem using Warnsdorff's rule and backtracking
        static void SolveKT()
        {
            // Initialize the solution matrix
            for (int x = 0; x < BoardSize; x++)
                for (int y = 0; y < BoardSize; y++)
                    boardGrid[x, y] = -1;

            int startX = 0;
            int startY = 0;
            boardGrid[startX, startY] = 0;

            if (!SolveKTUtil(startX, startY, 1))
            {
                Console.WriteLine("No solution exists");
            }
            else
            {
                PrintSolution(boardGrid);
            }
        }

        // A recursive utility function to solve the Knight's Tour problem using Warnsdorff's heuristic
        static bool SolveKTUtil(int x, int y, int moveCount)
        {
            Console.WriteLine($"SolveKTUtil called with x={x}, y={y}, moveCount={moveCount}");

            if (moveCount == BoardSize * BoardSize)
                return true;

            // Arrays to store possible moves and their scores
            int[][] moves = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                int nextX = x + xMove[i];
                int nextY = y + yMove[i];
                if (IsSquareSafe(nextX, nextY))
                {
                    moves[i] = new int[] { nextX, nextY, CountVisitedNeighbors(nextX, nextY) };
                }
                else
                {
                    moves[i] = new int[] { -1, -1, int.MaxValue }; // Invalid move
                }
            }

            // Sort moves by their scores (Warnsdorff's heuristic)
            Array.Sort(moves, (a, b) => a[2].CompareTo(b[2]));

            // Try all next moves in order of their heuristic scores
            for (int i = 0; i < 8; i++)
            {
                int nextX = moves[i][0];
                int nextY = moves[i][1];
                if (nextX == -1 && nextY == -1) // No more valid moves
                    break;

                boardGrid[nextX, nextY] = moveCount;
                if (SolveKTUtil(nextX, nextY, moveCount + 1))
                    return true;

                // Backtracking
                boardGrid[nextX, nextY] = -1;
            }

            return false;
        }

        // Utility function to count onward moves from a given position according to Warnsdorff's heuristic
        static int CountVisitedNeighbors(int x, int y)
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                int nextX = x + xMove[i];
                int nextY = y + yMove[i];
                if (IsSquareSafe(nextX, nextY))
                    count++;
            }
            return count;
        }

        // Check if x, y are valid indexes for an N*N chessboard
        static bool IsSquareSafe(int x, int y)
        {
            return x >= 0 && x < BoardSize && y >= 0 && y < BoardSize && boardGrid[x, y] == -1;
        }

        // Utility function to print solution matrix
        static void PrintSolution(int[,] solution)
        {
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                    Console.Write(solution[x, y].ToString().PadLeft(4, ' '));
                Console.WriteLine();
            }
        }
    }
}

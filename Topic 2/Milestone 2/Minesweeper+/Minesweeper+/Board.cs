//Christian Gonzalez -- CST-250 -- 5/6/24 This is original work, some structural inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Board
    {
        public int Size { get; private set; }
        public Cell[,] Grid { get; private set; }
        public float Difficulty { get; set; }
        public int MineCount { get; private set; } // Store the number of mines

        public Board(int size, float difficulty)
        {
            ValidateInputs(size, difficulty);
            Size = size;
            Difficulty = difficulty;
            MineCount = (int)(size * size * difficulty);
            Grid = new Cell[size, size];
            InitializeCells();
            SetupLiveNeighbors();
        }
        private void ValidateInputs(int size, float difficulty)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than zero.", nameof(size));
            }
            if (difficulty < 0 || difficulty > 1)
            {
                throw new ArgumentException("Difficulty must be between 0 and 1.", nameof(difficulty));
            }
            if (size * size < (int)(size * size * difficulty))
            {
                throw new ArgumentException("MineCount cannot exceed the number of cells on the board.");
            }
        }
        private void InitializeCells()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j);
                }
            }
        }
        public void SetupLiveNeighbors()
        {
            List<int> positions = ShufflePositions();

            // Place mines
            for (int i = 0; i < MineCount; i++)
            {
                int pos = positions[i];
                int row = pos / Size;
                int col = pos % Size;
                Grid[row, col].Live = true;
            }
        }
        private List<int> ShufflePositions()
        {
            List<int> positions = Enumerable.Range(0, Size * Size).ToList();
            Random rand = new Random();
            for (int i = positions.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = positions[i];
                positions[i] = positions[j];
                positions[j] = temp;
            }
            return positions;
        }
        public void CalculateLiveNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j].Live)
                    {
                        Grid[i, j].LiveNeighbors = 9;
                        continue;
                    }

                    int liveCount = 0;
                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            int ni = i + di, nj = j + dj;
                            if (ni >= 0 && ni < Size && nj >= 0 && nj < Size && Grid[ni, nj].Live)
                            {
                                liveCount++;
                            }
                        }
                    }
                    Grid[i, j].LiveNeighbors = liveCount;
                }
            }
        }
        public int CountMines()
        {
            int mineCount = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j].Live)
                    {
                        mineCount++;
                    }
                }
            }
            return mineCount;
        }
        public void RevealCell(int row, int col, int depth = 0)
        {
            const int MAX_DEPTH = 2; // Maximum recursion depth
            if (row < 0 || row >= Size || col < 0 || col >= Size || Grid[row, col].Visited)
                return; // Boundary and visited check

            Cell cell = Grid[row, col];
            if (cell.Live)
                return; // Stop if it's a mine

            cell.Visited = true; // Mark the cell as visited

            if (cell.LiveNeighbors == 0 && depth < MAX_DEPTH)
            {
                // Recursively reveal all adjacent cells up to a certain depth
                for (int di = -1; di <= 1; di++)
                {
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        if (di == 0 && dj == 0) continue; // Skip the current cell
                        int ni = row + di, nj = col + dj;
                        RevealCell(ni, nj, depth + 1); // Recursive call with increased depth
                    }
                }
            }
        }
        public bool CheckWinCondition()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell cell = Grid[i, j];
                    if (!cell.Live && !cell.Visited)
                        return false; // If there's any non-mine cell that hasn't been visited, game is not over
                }
            }
            return true; // All non-mine cells have been visited
        }
    }
}

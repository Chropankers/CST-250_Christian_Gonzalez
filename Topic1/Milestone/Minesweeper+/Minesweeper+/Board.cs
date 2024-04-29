namespace Models
{
    //Christian Gonzalez -- CST-250 -- 4/28/24 This is original work, some structural inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
    public class Board
    {
        // Properties
        public int Size { get; private set; }
        public Cell[,] Grid { get; private set; }
        public float Difficulty { get; set; } // Percentage of cells that are bombs

        // Constructor
        public Board(int size, float difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Grid = new Cell[size, size];
            InitializeCells();
            SetupLiveNeighbors();
        }

        // Initializes all cells in the grid
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

        // Randomly assigns live bombs to cells based on the difficulty level
        public void SetupLiveNeighbors()
        {
            int bombs = (int)(Size * Size * Difficulty);
            Random rand = new Random();
            while (bombs > 0)
            {
                int row = rand.Next(Size);
                int col = rand.Next(Size);
                if (!Grid[row, col].Live)
                {
                    Grid[row, col].Live = true;
                    bombs--;
                }
            }
        }

        // Calculates the number of live neighbors for each cell
        public void CalculateLiveNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j].Live)
                    {
                        Grid[i, j].LiveNeighbors = 9; // Indicates the cell is a bomb, overriding neighbor count
                        continue;
                    }

                    int liveCount = 0;
                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            int ni = i + di, nj = j + dj;
                            if (ni >= 0 && ni < Size && nj >= 0 && nj < Size)
                            {
                                if (Grid[ni, nj].Live)
                                {
                                    liveCount++;
                                }
                            }
                        }
                    }
                    Grid[i, j].LiveNeighbors = liveCount;
                }
            }
        }

    }
}

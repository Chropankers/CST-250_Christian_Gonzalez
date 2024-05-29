using System;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper;
using System.Diagnostics;
// Christian Gonzalez/CST-250/This is original work, some inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        private int gridSize;
        private Board board;
        private Button[,] buttons;
        private Stopwatch stopwatch;

        public GameForm(int size)
        {
            gridSize = size;
            InitializeComponent();
            InitializeGame();
        }

        // Initializes the game components and sets up the game board
        private void InitializeGame()
        {
            board = new Board(gridSize, 0.2f); // Example difficulty
            board.CalculateLiveNeighbors();
            buttons = new Button[gridSize, gridSize];
            stopwatch = new Stopwatch();
            CreateGrid();
        }

        // Handles form load event to start the stopwatch and timer
        private void GameForm_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer.Start();
        }

        // Updates the stopwatch display
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblStopwatch.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }

        // Creates the grid of buttons for the Minesweeper game
        private void CreateGrid()
        {
            this.SuspendLayout();
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(30 * col, 60 + 30 * row),
                        Tag = new Point(row, col),
                        BackColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ImageAlign = ContentAlignment.MiddleCenter
                    };
                    btn.Click += Button_Click;
                    btn.MouseUp += Button_RightClick;
                    buttons[row, col] = btn;
                    this.Controls.Add(btn);
                }
            }
            this.ResumeLayout(false);
        }

        // Handles left-click events on the buttons
        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                Point point = (Point)btn.Tag!;
                int row = point.X;
                int col = point.Y;
                HandleCellClick(row, col, btn);
            }
        }

        // Handles right-click events on the buttons
        private void Button_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is Button btn)
            {
                Point point = (Point)btn.Tag!;
                int row = point.X;
                int col = point.Y;
                HandleRightClick(row, col, btn);
            }
        }

        // Processes left-clicks on cells, updating the game state accordingly
        private void HandleCellClick(int row, int col, Button btn)
        {
            Cell cell = board.Grid[row, col];
            if (cell.Live)
            {
                btn.Image = ResizeImage(MinesweeperGUI.Properties.Resources.mine, 30, 30); // Set mine image
                btn.BackColor = Color.Red;
                RevealBoard(false);
                MessageBox.Show("Game Over! You clicked on a mine.");
                stopwatch.Stop();
                timer.Stop();
                return;
            }
            board.FloodFill(row, col);
            UpdateGrid();
            if (board.CheckWinCondition())
            {
                RevealBoard(true);
                stopwatch.Stop();
                timer.Stop();
                MessageBox.Show($"Congratulations! You've cleared all non-mine cells in {stopwatch.Elapsed.TotalSeconds} seconds.");
            }
        }

        // Processes right-clicks on cells, toggling the flag image
        private void HandleRightClick(int row, int col, Button btn)
        {
            if (!board.Grid[row, col].Visited)
            {
                if (btn.Image == MinesweeperGUI.Properties.Resources.flag)
                {
                    btn.Image = null; // Remove flag image
                }
                else
                {
                    btn.Image = ResizeImage(MinesweeperGUI.Properties.Resources.flag, 30, 30); // Set flag image
                }
            }
        }

        // Updates the grid display based on the current game state
        private void UpdateGrid()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Cell cell = board.Grid[row, col];
                    Button btn = buttons[row, col];
                    if (cell.Visited)
                    {
                        btn.BackColor = Color.White;
                        if (cell.LiveNeighbors > 0)
                        {
                            btn.Text = cell.LiveNeighbors.ToString(); // Display the number of adjacent mines
                            btn.ForeColor = GetNumberColor(cell.LiveNeighbors); // Set color for readability
                            btn.Font = new Font(btn.Font, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        // Reveals the entire board, showing mines and numbers based on the game outcome
        private void RevealBoard(bool won)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Cell cell = board.Grid[row, col];
                    Button btn = buttons[row, col];
                    if (cell.Live)
                    {
                        btn.Image = ResizeImage(won ? MinesweeperGUI.Properties.Resources.flag : MinesweeperGUI.Properties.Resources.mine, 30, 30);
                        btn.BackColor = Color.Yellow;
                    }
                    else if (!cell.Visited)
                    {
                        btn.BackColor = Color.White;
                        if (cell.LiveNeighbors > 0)
                        {
                            btn.Text = cell.LiveNeighbors.ToString(); // Display the number of adjacent mines
                            btn.ForeColor = GetNumberColor(cell.LiveNeighbors); // Set color for readability
                            btn.Font = new Font(btn.Font, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        // Returns the color associated with the number of adjacent mines
        private Color GetNumberColor(int number)
        {
            return number switch
            {
                1 => Color.Blue,
                2 => Color.Green,
                3 => Color.Red,
                4 => Color.DarkBlue,
                5 => Color.Brown,
                6 => Color.Cyan,
                7 => Color.Black,
                8 => Color.Gray,
                _ => Color.Black,
            };
        }

        // Resizes the given image to the specified width and height
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        // Handles the Play Again button click to restart the game
        private void BtnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            InitializeGame();
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.lblStopwatch);
            this.Controls.Add(this.btnDebugWin);
            btnDebugWin.Visible = true; // Ensure the debug button is hidden
            stopwatch.Reset();
            lblStopwatch.Text = "00:00:00";
            stopwatch.Start();
            timer.Start();
        }

        // Handles the Debug Win button click to simulate a win condition
        private void BtnDebugWin_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Cell cell = board.Grid[row, col];
                    if (!cell.Live)
                    {
                        cell.Visited = true;
                    }
                }
            }
            UpdateGrid();
            if (board.CheckWinCondition())
            {
                RevealBoard(true);
                stopwatch.Stop();
                timer.Stop();
                MessageBox.Show($"Congratulations! You've cleared all non-mine cells in {stopwatch.Elapsed.TotalSeconds} seconds.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper;
using System.Diagnostics;

namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        private int gridSize;
        private int difficultyLevel;
        private Board board;
        private Button[,] buttons;
        private Stopwatch stopwatch;
        private List<PlayerStats> allScores;
        private string scoreFilePath = "highscores.txt";

        public GameForm(int size, int difficultyLevel)
        {
            gridSize = size;
            this.difficultyLevel = difficultyLevel;
            InitializeComponent();
            InitializeGame();
            allScores = PlayerStats.LoadScoresFromFile(scoreFilePath);
        }

        private void InitializeGame()
        {
            board = new Board(gridSize, 0.2f); // Example difficulty
            board.CalculateLiveNeighbors();
            buttons = new Button[gridSize, gridSize];
            stopwatch = new Stopwatch();
            CreateGrid();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblStopwatch.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }

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
                SaveScore("Player", difficultyLevel, stopwatch.Elapsed);
                ShowHighScores();
                return;
            }
            board.FloodFill(row, col);
            UpdateGrid();
            if (board.CheckWinCondition())
            {
                RevealBoard(true);
                stopwatch.Stop();
                timer.Stop();
                var playerInitials = Prompt.ShowDialog("Enter your initials", "You Win!");
                SaveScore(playerInitials, difficultyLevel, stopwatch.Elapsed);
                ShowHighScores();
                MessageBox.Show($"Congratulations! You've cleared all non-mine cells in {stopwatch.Elapsed.TotalSeconds} seconds.");
            }
        }

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
                SaveScore("DBG", difficultyLevel, stopwatch.Elapsed); // Save debug score
                ShowHighScores();
                MessageBox.Show($"Congratulations! You've cleared all non-mine cells in {stopwatch.Elapsed.TotalSeconds} seconds.");
            }
        }

        private void SaveScore(string playerInitials, int difficultyLevel, TimeSpan timeElapsed)
        {
            var playerStats = new PlayerStats(playerInitials, difficultyLevel, timeElapsed);
            allScores.Add(playerStats);
            PlayerStats.SaveScoresToFile(scoreFilePath, allScores);
        }

        private void ShowHighScores()
        {
            var highScoreForm = new HighScoreForm(allScores, GetDifficultyLevel());
            highScoreForm.ShowDialog(); // Use ShowDialog to make sure it appears modally
        }

        private int GetDifficultyLevel()
        {
            return difficultyLevel; // Return the stored difficulty level
        }
    }

    // Utility class to prompt for user input
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}

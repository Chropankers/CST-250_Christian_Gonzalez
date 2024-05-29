using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
// Christian Gonzalez/CST-250/This is a work based upon the Activity 5 Assignment for Programming in C# II, Grand Canyon University
namespace StopWatch
{
    public partial class Form1 : Form
    {
        public static Stopwatch watch = new Stopwatch();
        private Random random = new Random();
        private int score = 0;
        private int misses = 0;
        private int lives = 3;
        private int highScore = 0;
        private System.Windows.Forms.Timer gameTimer;
        private List<Button> decoyButtons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Initialize the game state and setup the timer
        private void InitializeGame()
        {
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000; // 1 second intervals
            gameTimer.Tick += timer1_Tick;

            // Create initial decoy button
            CreateDecoyButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            watch.Start();
            gameTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            watch.Stop();
            gameTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            watch.Reset();
            label1.Text = "00:00:00.000";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!watch.IsRunning) return; // Exit if the game has not started

            label1.Text = string.Format("{0:hh\\:mm\\:ss\\.fff}", watch.Elapsed);

            if (random.Next(0, 10) < 5)
            {
                button4.Left = random.Next(0, this.Width - button4.Width);
                button4.Top = random.Next(0, this.Height - button4.Height);
                button4.Visible = true;

                // Move decoy buttons
                foreach (var decoy in decoyButtons)
                {
                    decoy.Left = random.Next(0, this.Width - decoy.Width);
                    decoy.Top = random.Next(0, this.Height - decoy.Height);
                    decoy.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!watch.IsRunning) return; // Exit if the game has not started

            score++;
            button4.Visible = false;
            UpdateLevel();

            // Reset and restart the timer
            watch.Stop();
            watch.Reset();
            watch.Start();

            // Increase difficulty and add decoy buttons
            if (score % 10 == 0)
            {
                button4.Width = Math.Max(20, button4.Width - 5);
                button4.Height = Math.Max(20, button4.Height - 5);
                gameTimer.Interval = Math.Max(200, gameTimer.Interval - 100);
            }

            if (score % 3 == 0)
            {
                CreateDecoyButton();
            }

            CheckGameEnd();
        }

        // Check if the game should end based on lives, score, or elapsed time
        private void CheckGameEnd()
        {
            if (lives <= 0 || score >= 50 || watch.Elapsed.TotalSeconds >= 60)
            {
                watch.Stop();
                gameTimer.Stop();
                button4.Visible = false;

                foreach (var decoy in decoyButtons)
                {
                    decoy.Visible = false;
                }

                if (score > highScore)
                {
                    highScore = score;
                }

                // Show Play Again button
                playAgainButton.Visible = true;
                MessageBox.Show($"Game Over! Your score: {score}. High score: {highScore}");
            }
        }

        // Reset the game and start over
        private void playAgainButton_Click(object sender, EventArgs e)
        {
            score = 0;
            misses = 0;
            lives = 3;
            watch.Reset();
            watch.Start();
            gameTimer.Start();
            playAgainButton.Visible = false;
            button4.Visible = true;
            this.BackColor = SystemColors.Control; // Reset background color

            // Reset decoy buttons
            foreach (var decoy in decoyButtons)
            {
                this.Controls.Remove(decoy);
            }
            decoyButtons.Clear();
            CreateDecoyButton();
        }

        // Update the game level and change background color based on score
        private void UpdateLevel()
        {
            if (score >= 20 && score < 30)
            {
                this.BackColor = Color.LightBlue;
            }
            else if (score >= 30)
            {
                this.BackColor = Color.LightGreen;
            }
        }

        // Handle missed clicks on the form
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!watch.IsRunning) return; // Exit if the game has not started

            base.OnMouseClick(e);

            // Check if the click was on the form and not on a button
            if (e.Button == MouseButtons.Left && !button4.Bounds.Contains(e.Location))
            {
                misses++;
                lives--;
                CheckGameEnd();
            }
        }

        // Create a new decoy button
        private void CreateDecoyButton()
        {
            Button decoyButton = new Button();
            decoyButton.BackColor = Color.Black;
            decoyButton.ForeColor = Color.Yellow;
            decoyButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            decoyButton.Size = new Size(100, 50);
            decoyButton.Text = "Don't click me!";
            decoyButton.Click += DecoyButton_Click;
            this.Controls.Add(decoyButton);
            decoyButtons.Add(decoyButton);
        }

        private void DecoyButton_Click(object sender, EventArgs e)
        {
            lives--;
            CheckGameEnd();
        }

        // Modify the appearance of buttons
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.BackColor = Color.Crimson;
            button4.ForeColor = Color.White;
            button4.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            button4.Text = "TARGET";
        }
    }
}

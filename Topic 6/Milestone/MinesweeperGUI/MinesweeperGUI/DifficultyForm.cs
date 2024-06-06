using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Minesweeper;  // Ensure this namespace is included

// Christian Gonzalez/CST-250/This is original work, some inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
namespace MinesweeperGUI
{
    public partial class DifficultyForm : Form
    {
        private List<PlayerStats> allScores;
        private string scoreFilePath = "highscores.txt";

        // Form init
        public DifficultyForm()
        {
            InitializeComponent();
            allScores = PlayerStats.LoadScoresFromFile(scoreFilePath);
        }

        // Radio button for difficulty select
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            int gridSize = 10; // Example grid size
            int difficultyLevel = 1; // Default to Easy

            if (rbtnEasy.Checked)
            {
                difficultyLevel = 1;
            }
            else if (rbtnMedium.Checked)
            {
                difficultyLevel = 2;
            }
            else if (rbtnHard.Checked)
            {
                difficultyLevel = 3;
            }

            GameForm gameForm = new GameForm(gridSize, difficultyLevel); // Pass difficulty level
            gameForm.Show();
            this.Hide();
        }

        // Button to show high scores
        private void btnShowScores_Click(object sender, EventArgs e)
        {
            int difficultyLevel = 1; // Default to Easy

            if (rbtnEasy.Checked)
            {
                difficultyLevel = 1;
            }
            else if (rbtnMedium.Checked)
            {
                difficultyLevel = 2;
            }
            else if (rbtnHard.Checked)
            {
                difficultyLevel = 3;
            }

            HighScoreForm highScoreForm = new HighScoreForm(allScores, difficultyLevel);
            highScoreForm.ShowDialog(); // Use ShowDialog to make it modal
        }
    }
}

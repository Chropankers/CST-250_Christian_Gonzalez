using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Minesweeper;

namespace MinesweeperGUI
{
    public partial class HighScoreForm : Form
    {
        private List<PlayerStats> allScores;
        private int difficultyLevel;

        public HighScoreForm(List<PlayerStats> scores, int difficultyLevel)
        {
            InitializeComponent();
            allScores = scores;
            this.difficultyLevel = difficultyLevel;
        }

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            DisplayHighScores();
        }

        private void DisplayHighScores()
        {
            var topScores = PlayerStats.GetTopScores(
                PlayerStats.FilterScoresByDifficulty(allScores, difficultyLevel), 5);

            lstHighScores.Items.Clear();
            foreach (var score in topScores)
            {
                lstHighScores.Items.Add(score.ToString());
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClearScores_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all scores?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                allScores.Clear();
                PlayerStats.SaveScoresToFile("highscores.txt", allScores);
                DisplayHighScores();
            }
        }
    }
}

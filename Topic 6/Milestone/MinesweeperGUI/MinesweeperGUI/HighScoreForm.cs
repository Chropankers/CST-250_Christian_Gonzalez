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
            var topScores = allScores
                .Where(s => s.DifficultyLevel == difficultyLevel)
                .OrderByDescending(s => s.Score)
                .Take(5)
                .ToList();

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
    }
}

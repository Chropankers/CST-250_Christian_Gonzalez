using System;
using System.Windows.Forms;
// Christian Gonzalez/CST-250/This is original work, some inspiration from https://www.codeproject.com/Articles/5293335/Minesweeper-Game-in-Csharp
namespace MinesweeperGUI
{
    public partial class DifficultyForm : Form
    {
        // Form init
        public DifficultyForm()
        {
            InitializeComponent();
        }

        // Radio button for difficulty select
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            int size;
            float difficulty;

            if (rbtnEasy.Checked)
            {
                size = 8;
                difficulty = 0.1f;
            }
            else if (rbtnMedium.Checked)
            {
                size = 16;
                difficulty = 0.15f;
            }
            else if (rbtnHard.Checked)
            {
                size = 24;
                difficulty = 0.2f;
            }
            else
            {
                MessageBox.Show("Please select a difficulty level.");
                return;
            }

            GameForm gameForm = new GameForm(size);
            gameForm.Show();
            this.Hide();
        }
    }
}

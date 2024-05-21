using System;
using System.Windows.Forms;
// Christian Gonzalez/CST-250/5-20-24 This is original work
namespace MinesweeperGUI
{
    public partial class DifficultyForm : Form
    {
        public DifficultyForm()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            OpenGameForm(10);
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            OpenGameForm(15);
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            OpenGameForm(20);
        }

        private void OpenGameForm(int size)
        {
            GameForm gameForm = new GameForm(size);
            gameForm.Show();
            this.Hide();
        }
    }
}

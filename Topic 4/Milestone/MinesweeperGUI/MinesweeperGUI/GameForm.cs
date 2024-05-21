using System;
using System.Drawing;
using System.Windows.Forms;
// Christian Gonzalez/CST-250/5-20-24 This is original work
namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        private int gridSize;

        public GameForm(int size)
        {
            gridSize = size;
            InitializeComponent();
            CreateGrid();
        }

        private void CreateGrid()
        {
            this.SuspendLayout();
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(30 * col, 30 * row);
                    btn.Click += Button_Click;
                    this.Controls.Add(btn);
                }
            }
            this.ResumeLayout(false);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Gray; // Change color to indicate click
            // Additional click handling logic can be added here later
        }
    }
}

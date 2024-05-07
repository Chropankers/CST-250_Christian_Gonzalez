using ChessBoardModel;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {
        static public Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public string[] chessPieces = { "Bishop", "King", "Knight", "Queen", "Rook" };

        public Form1()
        {
            InitializeComponent();
            InitializePieceSelectionComboBox(); // Setup the ComboBox for chess piece selection
            populateGrid(); // Setup the grid of buttons on the form
        }

        private void InitializePieceSelectionComboBox()
        {
            comboBox1.Items.AddRange(chessPieces); // Add chess pieces to comboBox
            comboBox1.SelectedIndex = 0; // Set default selection to the first item
        }


        public void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size; // Calculate the size of each button to fit the panel
            panel1.Height = panel1.Width; // Ensure the panel is square

            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Location = new Point(buttonSize * c, buttonSize * r)
                    };

                    btnGrid[r, c].Click += Grid_Button_Click; // Assign click event handler to each button
                    panel1.Controls.Add(btnGrid[r, c]); // Add the button to the panel
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString(); // Store row and column as Tag
                    btnGrid[r, c].TextAlign = ContentAlignment.MiddleCenter; // Center text in button
                }
            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string[] strArr = clickedButton.Tag.ToString().Split("|");
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            Cell currentCell = myBoard.theGrid[r, c];
            string selectedPiece = comboBox1.SelectedItem?.ToString() ?? "Knight"; // Default to "Knight" if nothing selected

            // Update board for moves and occupation
            myBoard.MarkNextLegalMoves(currentCell, selectedPiece, true); // True for occupying new cell

            // Update UI
            updateButtonLabels();
            ResetButtonBackgrounds();
            clickedButton.BackColor = Color.Cornsilk; // Highlight the selected button
        }




        private void ResetButtonBackgrounds()
        {
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].BackColor = default(Color);
                }
            }
        }

        public void updateButtonLabels()
        {
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c].Text = ""; // Clear existing text
                    if (myBoard.theGrid[r, c].CurrentlyOccupied)
                    {
                        btnGrid[r, c].Text = comboBox1.SelectedItem?.ToString() ?? "Piece";
                    }
                    if (myBoard.theGrid[r, c].LegalNextMove)
                    {
                        btnGrid[r, c].Text += (btnGrid[r, c].Text.Length > 0 ? " + Legal" : "Legal");
                    }
                }
            }
        }


        private string GetChessPieceNameByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return "Bishop";
                case 1:
                    return "King";
                case 2:
                    return "Knight";
                case 3:
                    return "Queen";
                case 4:
                    return "Rook";
                default:
                    return "Unknown"; // Default case to handle unexpected index
            }
        }


    }
}

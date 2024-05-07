using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Christian Gonzalez/CST-250/This is a work based upon the Activity x Assignment for Programming in C# II, Grand Canyon University
namespace ChessBoardModel
{
    public class Board
    {
        // The board is always square. Usually 8x8.
        public int Size { get; set; }

        // 2d array of Cell objects
        public Cell[,] theGrid;

        // Constructor
        public Board(int s)
        {
            Size = s;
            // we must initialize the array to avoid Null Exception errors
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++) // Fixed to use 'j'
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece, bool occupy)
        {
            // Clear previous legal moves and optionally clear occupations
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    theGrid[r, c].LegalNextMove = false;
                    if (occupy && theGrid[r, c].CurrentlyOccupied)
                    {
                        theGrid[r, c].CurrentlyOccupied = false; // Only clear this if re-setting occupation elsewhere
                    }
                }
            }

            // Optionally, set the current cell as occupied
            if (occupy)
            {
                currentCell.CurrentlyOccupied = true;
            }

            // Set the current cell as occupied if required
            if (occupy)
            {
                currentCell.CurrentlyOccupied = true; // Set current as occupied
            }

            // step 2 - find all legal moves and mark the square.
            switch (chessPiece)
            {
                case "King":
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0) continue; // Skip the current cell
                            MarkMove(currentCell.RowNumber + i, currentCell.ColumnNumber + j);
                        }
                    }
                    break;

                case "Queen":
                    // Horizontal and vertical moves (like the Rook)
                    for (int i = 0; i < Size; i++)
                    {
                        MarkMove(currentCell.RowNumber, i);
                        MarkMove(i, currentCell.ColumnNumber);
                    }
                    // Diagonal moves (like the Bishop)
                    for (int i = 1; i < Size; i++)
                    {
                        MarkMove(currentCell.RowNumber + i, currentCell.ColumnNumber + i);
                        MarkMove(currentCell.RowNumber + i, currentCell.ColumnNumber - i);
                        MarkMove(currentCell.RowNumber - i, currentCell.ColumnNumber + i);
                        MarkMove(currentCell.RowNumber - i, currentCell.ColumnNumber - i);
                    }
                    break;

                case "Rook":
                    for (int i = 0; i < Size; i++)
                    {
                        MarkMove(currentCell.RowNumber, i); // Horizontal moves
                        MarkMove(i, currentCell.ColumnNumber); // Vertical moves
                    }
                    break;

                case "Bishop":
                    for (int i = 1; i < Size; i++)
                    {
                        MarkMove(currentCell.RowNumber + i, currentCell.ColumnNumber + i); // Down-right
                        MarkMove(currentCell.RowNumber + i, currentCell.ColumnNumber - i); // Down-left
                        MarkMove(currentCell.RowNumber - i, currentCell.ColumnNumber + i); // Up-right
                        MarkMove(currentCell.RowNumber - i, currentCell.ColumnNumber - i); // Up-left
                    }
                    break;

                case "Knight":
                    // Possible Knight moves (L-shapes)
                    int[] movesX = { 2, 1, -1, -2, -2, -1, 1, 2 };
                    int[] movesY = { 1, 2, 2, 1, -1, -2, -2, -1 };
                    for (int k = 0; k < 8; k++)
                    {
                        MarkMove(currentCell.RowNumber + movesX[k], currentCell.ColumnNumber + movesY[k]);
                    }
                    break;
            }
        }
        // Helper method to mark moves within bounds
        private void MarkMove(int row, int col)
        {
            if (row >= 0 && row < Size && col >= 0 && col < Size)
            {
                theGrid[row, col].LegalNextMove = true;
            }
        }
    }
}
using System.Runtime.Intrinsics.X86;
using ChessBoardModel;

// Christian Gonzalez/CST-250/This is a work based upon the Activity 2 Assignment for Programming in C# II, Grand Canyon University
namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            // Show the empty Chessboard
            printGrid(myBoard);

            // Get the location of the chess piece
            Cell myLocation = setCurrentCell();

            // Ask which piece to place on the board and validate input
            string pieceType = getPieceType();

            // Calculate and mark the cells where legal moves are possible
            myBoard.MarkNextLegalMoves(myLocation, pieceType);

            // Show the chess board with updated legal moves
            printGrid(myBoard);

            // Wait for another return key to end the program
            Console.ReadLine();
        }

        static public void printGrid(Board myBoard)
        {
            Console.WriteLine("+---+---+---+---+---+---+---+---+");
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Console.Write("|");
                    if (myBoard.theGrid[i, j].CurrentlyOccupied)
                        Console.Write(" X ");
                    else if (myBoard.theGrid[i, j].LegalNextMove)
                        Console.Write(" + ");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine("|");
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
            }
        }

        static public Cell setCurrentCell()
        {
            int currentRow = -1;
            int currentColumn = -1;

            while (true)
            {
                Console.WriteLine("Enter your current row number (0 to 7):");
                if (int.TryParse(Console.ReadLine(), out currentRow) && currentRow >= 0 && currentRow < 8)
                    break;
                Console.WriteLine("Invalid input. Please enter a number between 0 and 7.");
            }

            while (true)
            {
                Console.WriteLine("Enter your current column number (0 to 7):");
                if (int.TryParse(Console.ReadLine(), out currentColumn) && currentColumn >= 0 && currentColumn < 8)
                    break;
                Console.WriteLine("Invalid input. Please enter a number between 0 and 7.");
            }

            myBoard.theGrid[currentRow, currentColumn].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentColumn];
        }

        static public string getPieceType()
        {
            string[] validPieces = { "Knight", "King", "Queen", "Rook", "Bishop" };
            while (true)
            {
                Console.WriteLine("Enter the type of chess piece (Knight, King, Queen, Rook, Bishop):");
                string input = Console.ReadLine();
                foreach (string piece in validPieces)
                {
                    if (input.Equals(piece, StringComparison.OrdinalIgnoreCase))
                    {
                        return input;
                    }
                }
                Console.WriteLine("Invalid piece type. Please enter a valid chess piece.");
            }
        }
    }
}
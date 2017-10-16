using System;

namespace chessboard
{
    class View {
        public static void printChessboard(Chessboard chessboard) {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.GetPiece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        printPiece(chessboard.GetPiece(i,j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }        
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece) {
            if (piece.Color == Color.White) {
                Console.Write(piece);
            }
            else {
                var consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
        }
    }
}
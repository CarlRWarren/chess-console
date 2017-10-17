using System;
using chess;
using chessboard;

namespace chess_console
{
    class View {
        public static void PrintChessboard(Chessboard chessboard) {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                    PrintPiece(chessboard.GetPiece(i, j));
                Console.WriteLine();
            }        
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition ReadChessPosition()
        {
            var consoleEntry = Console.ReadLine();
            var column = consoleEntry[0];
            var line = int.Parse(consoleEntry[1] + "");
            return new ChessPosition(column, line);
        }

        internal static void PrintChessboard(Chessboard chessboard, bool[,] possibleMoves)
        {
            var defaultBackground = Console.BackgroundColor;
            var changedBackground = ConsoleColor.DarkGray;
            
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (possibleMoves[i, j])
                        Console.BackgroundColor = changedBackground;
                    else
                        Console.BackgroundColor = defaultBackground;
                    PrintPiece(chessboard.GetPiece(i, j));
                    Console.BackgroundColor = defaultBackground;
                }
                Console.WriteLine();
            }        
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = defaultBackground;
        }

        public static void PrintPiece(Piece piece) {
            if (piece == null)
                Console.Write("- ");
            else
            {            
                if (piece.Color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    var consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }
    }
}
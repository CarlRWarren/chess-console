using System;

namespace chessboard
{
    class View {
        public static void printChessboard(Chessboard chessboard) {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.getPiece(i, j) == null) {
                        Console.Write("- ");
                    }
                    Console.Write(chessboard.getPiece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
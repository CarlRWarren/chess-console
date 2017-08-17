using System;

namespace chessboard
{
    class View {
        public static void printChessboard(Chessboard chessboard) {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    Console.Write(chessboard.piece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
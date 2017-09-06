using System;
using chess;
using chessboard;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var chessboard = new Chessboard(8, 8);

                chessboard.movePiece(new Rook(chessboard, Color.Black), new Position(0, 0));
                chessboard.movePiece(new Rook(chessboard, Color.Black), new Position(1, 3));
                chessboard.movePiece(new King(chessboard, Color.Black), new Position(2, 4));

                View.printChessboard(chessboard);
                Console.ReadLine();
            }
            catch (ChessboardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

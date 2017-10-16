using System;
using chess;
using chessboard;

namespace chessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new PlayChess();
                View.printChessboard(game.Chessboard);
                Console.ReadLine();
            }
            catch (ChessboardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

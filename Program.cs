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
                var game = new PlayChess();
                
                while (!game.Ended) {
                    Console.Clear();
                    View.PrintChessboard(game.Chessboard);

                    Console.WriteLine();
                    Console.Write("From: ");
                    var from = View.ReadChessPosition().ToPosition(); 
                    Console.Write("To: ");
                    var to = View.ReadChessPosition().ToPosition();

                    game.PlayMove(from, to);
                }
                Console.ReadLine();
            }
            catch (ChessboardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

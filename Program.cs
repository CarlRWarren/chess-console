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

                    Console.WriteLine("Turn: " + game.Turn);
                    Console.WriteLine("Waiting Player: " + game.CurrentPlayer);

                    Console.WriteLine();
                    Console.Write("From: ");
                    var from = View.ReadChessPosition().ToPosition(); 

                    bool[,] possibleMoves = game.Chessboard.GetPiece(from).PossibleMoves();
                    
                    Console.Clear();
                    View.PrintChessboard(game.Chessboard, possibleMoves);

                    Console.WriteLine();
                    Console.Write("To: ");
                    var to = View.ReadChessPosition().ToPosition();

                    game.DoTurn(from, to);
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

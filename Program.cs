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
                    try
                    {
                        Console.Clear();
                        View.PrintChessboard(game.Chessboard);
                        Console.WriteLine();

                        Console.WriteLine("Turn: " + game.Turn);
                        Console.WriteLine("Waiting Next Move: " + game.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write("From: ");
                        var from = View.ReadChessPosition().ToPosition();
                        game.CheckFromPosition(from);

                        bool[,] possibleMoves = game.Chessboard.GetPiece(from).PossibleMoves();
                        
                        Console.Clear();
                        View.PrintChessboard(game.Chessboard, possibleMoves);

                        Console.WriteLine();
                        Console.Write("To: ");
                        var to = View.ReadChessPosition().ToPosition();
                        game.CheckToPosition(from, to);

                        game.PlayTurn(from, to);
                    }
                    catch (ChessboardException exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (ChessboardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

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
                var game = new ChessGame();

                while (!game.Ended)
                {
                    try
                    {
                        Console.Clear();
                        View.PrintGame(game);

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
                Console.Clear();
                View.PrintGame(game);
            }
            catch (ChessboardException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

using System;
using chessboard;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var chessboard = new Chessboard(8, 8);

            View.printChessboard(chessboard);
            Console.ReadLine();
        }
    }
}

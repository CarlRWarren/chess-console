using System;
using chessboard;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = new Position(3, 4);
            Console.WriteLine("Posição: {0}", position);
        }
    }
}

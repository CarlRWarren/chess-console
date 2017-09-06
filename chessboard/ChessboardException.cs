using System;

namespace chessboard
{
    public class ChessboardException : Exception {
        public ChessboardException(string message) : base(message) {}
    }
}
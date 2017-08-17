namespace chessboard
{
    class Piece {
        public Position Position { get; private set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Position position, Chessboard chessboard, Color color) {
           Position = position;
           Chessboard = chessboard;
           Color = color;
           Moves = 0;
        }
    }
}
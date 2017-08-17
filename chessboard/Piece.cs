namespace chessboard
{
    class Piece {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color) {
           Position = null;
           Chessboard = chessboard;
           Color = color;
           Moves = 0;
        }
    }
}
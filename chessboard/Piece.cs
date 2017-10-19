namespace chessboard
{
    abstract class Piece {
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

        public void IncrementMoves() {
            Moves++;
        }

        public void DecrementMoves() {
            Moves--;
        }

        public bool CheckPossibleMoves() {
            var matrix = PossibleMoves();
            for (int i = 0; i < Chessboard.Lines; i++)
                for (int j = 0; j < Chessboard.Columns; j++)
                    if (matrix[ i, j])
                        return true;
            return false;
        }

        public bool CanMoveTo(Position position) {
            return PossibleMoves()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
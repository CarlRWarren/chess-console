using chessboard;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        private bool CanMove(Position position)
        {
            var piece = Chessboard.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Lines, Chessboard.Columns];

            var position = new Position(0, 0);

            // N
            position.SetValues(Position.Line - 1, Position.Column);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(position.Line - 1, Position.Column);
            }

            // S
            position.SetValues(Position.Line + 1, Position.Column);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(position.Line + 1, Position.Column);
            }

            // E
            position.SetValues(Position.Line, Position.Column + 1);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(Position.Line, position.Column + 1);
            }

            // W
            position.SetValues(Position.Line, Position.Column - 1);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(Position.Line, position.Column - 1);
            }

            return matrix;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
using chessboard;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Chessboard chessboard, Color color) : base(chessboard, color)
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

            // NO
            position.SetValues(Position.Line - 1, Position.Column - 1);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(position.Line - 1, Position.Column - 1);
            }

            // NE
            position.SetValues(Position.Line - 1, Position.Column + 1);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(position.Line - 1, Position.Column + 1);
            }

            // SE
            position.SetValues(Position.Line + 1, Position.Column + 1);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(Position.Line + 1, position.Column + 1);
            }

            // W
            position.SetValues(Position.Line + 1, Position.Column - 1);
            while (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.GetPiece(position) != null && Chessboard.GetPiece(position).Color != Color)
                    break;
                position.SetValues(Position.Line + 1, position.Column - 1);
            }

            return matrix;
        }

        public override string ToString()
        {
            return "B";
        }


    }
}
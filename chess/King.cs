using chessboard;

namespace chess
{
    class King : Piece
    {
        public King(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        private bool CanMove(Position position){
            var piece = Chessboard.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Lines, Chessboard.Columns];

            var position = new Position(0, 0);
            
            // N
            position.SetValues(position.Line - 1, position.Column);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // NE
            position.SetValues(position.Line - 1, position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // E
            position.SetValues(position.Line, position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;
            
            // SE
            position.SetValues(position.Line + 1, position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // S
            position.SetValues(position.Line + 1, position.Column);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;
            
            // SW
            position.SetValues(position.Line + 1, position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;
            
            // W
            position.SetValues(position.Line, position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // NW
            position.SetValues(position.Line - 1, position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            return matrix;
        }

        public override string ToString() {
            return "K";
        }
    }
}
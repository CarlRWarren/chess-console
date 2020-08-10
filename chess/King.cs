using chessboard;

namespace chess
{
    public class King : Piece
    {
        private ChessGame game;
        public King(Chessboard chessboard, Color color, ChessGame game) : base(chessboard, color)
        {
            this.game = game;
        }

        private bool CanMove(Position position)
        {
            var piece = Chessboard.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }

        private bool TestRookForCastling(Position position)
        {
            var piece = Chessboard.GetPiece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.Moves == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Lines, Chessboard.Columns];

            var position = new Position(0, 0);

            // N
            position.SetValues(Position.Line - 1, Position.Column);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // NE
            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // E
            position.SetValues(Position.Line, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // SE
            position.SetValues(Position.Line + 1, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // S
            position.SetValues(Position.Line + 1, Position.Column);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // SW
            position.SetValues(Position.Line + 1, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // W
            position.SetValues(Position.Line, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            // NW
            position.SetValues(Position.Line - 1, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            if (Moves == 0 && !game.Mate)
            {
                // Roque Pequeno #SpecialMove
                var firstPosition = new Position(Position.Line, Position.Column + 3);
                if (TestRookForCastling(firstPosition))
                {
                    var positionOne = new Position(Position.Line, Position.Column + 1);
                    var positionTwo = new Position(Position.Line, Position.Column + 2);
                    if (Chessboard.GetPiece(positionOne) == null && Chessboard.GetPiece(positionTwo) == null)
                        matrix[Position.Line, Position.Column + 2] = true;
                }
                // Roque Grande #SpecialMove
                var secondPosition = new Position(Position.Line, Position.Column - 4);
                if (TestRookForCastling(secondPosition))
                {
                    var positionOne = new Position(Position.Line, Position.Column - 1);
                    var positionTwo = new Position(Position.Line, Position.Column - 2);
                    var positionThree = new Position(Position.Line, Position.Column - 3);
                    if (Chessboard.GetPiece(positionOne) == null && Chessboard.GetPiece(positionTwo) == null && Chessboard.GetPiece(positionThree) == null)
                        matrix[Position.Line, Position.Column - 2] = true;
                }
            }

            return matrix;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
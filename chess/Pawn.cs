using chessboard;

class Pawn : Piece
{
    public Pawn(Chessboard chessboard, Color color) : base(chessboard, color)
    {
    }

    private bool CanMove(Position position)
    {
        var piece = Chessboard.GetPiece(position);
        return piece == null || piece.Color != this.Color;
    }

    private bool ExistsOpponent(Position position)
    {
        var piece = Chessboard.GetPiece(position);
        return piece != null && !piece.Color.Equals(Color);
    }

    private bool Free(Position position)
    {
        return Chessboard.GetPiece(position) == null;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] matrix = new bool[Chessboard.Lines, Chessboard.Columns];

        var position = new Position(0, 0);

        if (Color == Color.White)
        {
            position.SetValues(Position.Line - 1, Position.Column);
            if (Chessboard.ValidPosition(position) && Free(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(Position.Line - 2, Position.Column);
            if (Chessboard.ValidPosition(position) && Free(position) && Moves == 0)
                matrix[position.Line, position.Column] = true;

            position.SetValues(Position.Line - 1, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && ExistsOpponent(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && ExistsOpponent(position))
                matrix[position.Line, position.Column] = true;
        }
        else
        {
            position.SetValues(Position.Line + 1, Position.Column);
            if (Chessboard.ValidPosition(position) && Free(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(Position.Line + 2, Position.Column);
            if (Chessboard.ValidPosition(position) && Free(position) && Moves == 0)
                matrix[position.Line, position.Column] = true;

            position.SetValues(Position.Line + 1, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && ExistsOpponent(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(Position.Line + 1, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && ExistsOpponent(position))
                matrix[position.Line, position.Column] = true;
        }

        return matrix;
    }

    public override string ToString()
    {
        return "P";
    }
}
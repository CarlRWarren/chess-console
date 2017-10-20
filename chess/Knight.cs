using chessboard;

class Knight : Piece
{
    public Knight(Chessboard chessboard, Color color) : base(chessboard, color)
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

        position.SetValues(Position.Line - 1, Position.Column - 2);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line - 2, Position.Column - 1);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line - 2, Position.Column + 1);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line - 1, Position.Column + 2);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line + 1, Position.Column + 2);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line + 2, Position.Column + 1);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line + 2, Position.Column - 1);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        position.SetValues(Position.Line + 1, Position.Column - 2);
        if (Chessboard.ValidPosition(position) && CanMove(position))
            matrix[position.Line, position.Column] = true;

        return matrix;
    }

    public override string ToString()
    {
        return "N";
    }
}
namespace chessboard
{
    class Chessboard {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Chessboard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece getPiece(int line, int column) {
            return Pieces[line, column];
        }

        public void movePiece(Piece piece, Position position) {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
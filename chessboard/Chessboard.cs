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

        public Piece getPiece(Position position) {
            return Pieces[position.Line, position.Column];
        }

        public bool existPiece(Position position) {
            validatePosition(position);
            return getPiece(position) != null;
        }

        public void movePiece(Piece piece, Position position) {
            if (existPiece(position))
                throw new ChessboardException("Can not move this piece.");
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool validPosition(Position position) {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns) {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position) {
            if (!validPosition(position))
                throw new ChessboardException("Invalid position!");
        }
    }
}
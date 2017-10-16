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

        public Piece GetPiece(int line, int column) {
            return Pieces[line, column];
        }

        public Piece GetPiece(Position position) {
            return Pieces[position.Line, position.Column];
        }

        public bool ExistPiece(Position position) {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        public void MovePiece(Piece piece, Position position) {
            if (ExistPiece(position))
                throw new ChessboardException("Can not move this piece.");
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position) {
            if (GetPiece(position) == null)
            return null;

            Piece aux = GetPiece(position);
            aux.Position = null;
            Pieces[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position) {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns) {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position) {
            if (!ValidPosition(position))
                throw new ChessboardException("Invalid position!");
        }
    }
}
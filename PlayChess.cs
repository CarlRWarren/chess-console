using System;
using chess;

namespace chessboard {
    class PlayChess {
        public Chessboard Chessboard {get; private set;}
        private int turn;
        private Color currentPlayer;

        public PlayChess() {
            Chessboard = new Chessboard(8,8);
            turn = 1;
            currentPlayer = Color.White;
            PutPieces();

        }

        private void PutPieces()
        {
            Chessboard.MovePiece(new Rook(Chessboard, Color.White), new ChessPosition('c', 1).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.White), new ChessPosition('c', 2).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.White), new ChessPosition('d', 2).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.White), new ChessPosition('e', 1).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.White), new ChessPosition('e', 2).ToPosition());
            Chessboard.MovePiece(new King(Chessboard, Color.White), new ChessPosition('d', 1).ToPosition());

            Chessboard.MovePiece(new Rook(Chessboard, Color.Black), new ChessPosition('c', 7).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.Black), new ChessPosition('c', 8).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.Black), new ChessPosition('d', 7).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.Black), new ChessPosition('e', 7).ToPosition());
            Chessboard.MovePiece(new Rook(Chessboard, Color.Black), new ChessPosition('e', 8).ToPosition());
            Chessboard.MovePiece(new King(Chessboard, Color.Black), new ChessPosition('d', 8).ToPosition());
        }

        public void PlayMoviment(Position origin, Position destination) {
            Piece piece = Chessboard.RemovePiece(origin);
            piece.IncrementMoves();

            Piece pieceTaken = Chessboard.RemovePiece(destination);
            Chessboard.MovePiece(piece, destination);
        }


    }
}
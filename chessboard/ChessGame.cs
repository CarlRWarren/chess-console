using System;
using System.Collections.Generic;
using chess;

namespace chessboard
{
    class ChessGame
    {
        public Chessboard Chessboard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Ended { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> allTaken;
        public bool Mate {get; private set; }

        public ChessGame()
        {
            Chessboard = new Chessboard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Ended = false;
            Mate = false;
            pieces = new HashSet<Piece>();
            allTaken = new HashSet<Piece>();
            PutPieces();
        }

        public void CheckFromPosition(Position position)
        {
            if (Chessboard.GetPiece(position) == null)
                throw new ChessboardException("Piece not found!");
            if (!CurrentPlayer.Equals(Chessboard.GetPiece(position).Color))
                throw new ChessboardException("The piece do not belongs to you!");
            if (!Chessboard.GetPiece(position).CheckPossibleMoves())
                throw new ChessboardException("Impossible to move.");
        }

        public void CheckToPosition(Position from, Position to) {
            if (!Chessboard.GetPiece(from).CanMoveTo(to))
                throw new ChessboardException("Invalid position.");
        }

        public HashSet<Piece> PiecesTaken(Color color){
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (var piece in allTaken)
            {
                if (piece.Color == color)
                    aux.Add(piece);
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color){
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (var piece in pieces)
            {
                if (piece.Color == color)
                    aux.Add(piece);
            }
            aux.ExceptWith(PiecesTaken(color));
            return aux;
        }

        private Color Opponent(Color color) {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece King(Color color) {
            foreach (var piece in InGamePieces(color)) {     
                if (piece is King) {
                    return piece;
                }
            }
            return null;
        }

        public bool CheckMate(Color color) {
            var king = King(color);
            if (king == null)
                throw new ChessboardException("King " + color + "not found.");
            foreach (var piece in InGamePieces(Opponent(color)))
            {
                bool[,] matrix = piece.PossibleMoves();
                if (matrix[king.Position.Line, king.Position.Column])
                    return true;
            }
            return false;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Chessboard.MovePiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Rook(Chessboard, Color.White));
            PutNewPiece('c', 2, new Rook(Chessboard, Color.White));
            PutNewPiece('d', 2, new Rook(Chessboard, Color.White));
            PutNewPiece('e', 2, new Rook(Chessboard, Color.White));
            PutNewPiece('e', 1, new Rook(Chessboard, Color.White));
            PutNewPiece('d', 1, new King(Chessboard, Color.White));
            
            PutNewPiece('c', 7, new Rook(Chessboard, Color.Black));
            PutNewPiece('c', 8, new Rook(Chessboard, Color.Black));
            PutNewPiece('d', 7, new Rook(Chessboard, Color.Black));
            PutNewPiece('e', 7, new Rook(Chessboard, Color.Black));
            PutNewPiece('e', 8, new Rook(Chessboard, Color.Black));
            PutNewPiece('d', 8, new King(Chessboard, Color.Black));
        }

        public void PlayTurn(Position from, Position to)
        {
            var pieceTaken = PlayMove(from, to);
            if (CheckMate(CurrentPlayer)) {
                UndoMove(from, to, pieceTaken);
                throw new ChessboardException("You can't put yourself in checkmate.");
            }
            
            Mate = CheckMate(Opponent(CurrentPlayer));

            Turn++;
            ChangeCurrentPlayer();
        }

        public void UndoMove(Position from, Position to, Piece pieceTaken)
        {
            var piece = Chessboard.RemovePiece(to);
            piece.DecrementMoves();
            if (pieceTaken != null) {
                Chessboard.MovePiece(pieceTaken, to);
                allTaken.Remove(pieceTaken);
            }
            Chessboard.MovePiece(piece, from);
        }

        private void ChangeCurrentPlayer()
        {
            if (CurrentPlayer.Equals(Color.White))
                CurrentPlayer = Color.Black;
            else
                CurrentPlayer = Color.White;
        }

        public Piece PlayMove(Position from, Position to)
        {
            Piece piece = Chessboard.RemovePiece(from);
            piece.IncrementMoves();

            Piece pieceTaken = Chessboard.RemovePiece(to);
            Chessboard.MovePiece(piece, to);

            if (pieceTaken != null)
                allTaken.Add(pieceTaken);

            return pieceTaken;
        }


    }
}
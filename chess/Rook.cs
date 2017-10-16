using chessboard;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            return "R";
        }
    }
}
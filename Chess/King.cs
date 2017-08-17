using chessboard;

namespace chess
{
    class King : Piece
    {
        public King(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString() {
            return "K";
        }
    }
}
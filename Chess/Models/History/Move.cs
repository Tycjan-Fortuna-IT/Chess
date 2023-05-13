namespace Chess.Models
{
    public class Move
    {
        public Tuple<int, int> FromField;

        public Tuple<int, int> ToField;

        public string MovedChess;

        public ColorEnum? MovedChessColor;

        public string? CapturedChessName;

        public ColorEnum? CapturedChessColor;

        public bool PromotionMove;

        public bool CastleMove;

        public bool CheckMove;

        public Move(Tuple<int, int> FromField, Tuple<int, int> ToField, string MovedChess,
            ColorEnum? MovedChessColor, string? CapturedChessName, ColorEnum? CapturedChessColor,
            bool PromotionMove = false, bool CastleMove = false, bool CheckMove = false)
        {
            this.FromField = FromField;
            this.ToField = ToField;
            this.MovedChess = MovedChess;
            this.MovedChessColor = MovedChessColor;
            this.CapturedChessName = CapturedChessName;
            this.CapturedChessColor = CapturedChessColor;
            this.PromotionMove = PromotionMove;
            this.CastleMove = CastleMove;
            this.CheckMove = CheckMove;
        }

        public static Move ConvertSanToMove(string SAN, ColorEnum Color)
        {
            IChess Piece = new Pawn(Color);

            if (char.IsUpper(SAN[0]))
            {
                Piece = GetPieceTypeFromChar(SAN[0], Color);
                SAN = SAN.Substring(1);
            }

            return new Move(
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 1),
                "moved",
                null,
                null,
                null
            );
        }

        static IChess GetPieceTypeFromChar(char piece, ColorEnum Color)
        {
            switch (piece)
            {
                case 'K': return new King(Color);
                case 'Q': return new Queen(Color);
                case 'R': return new Rook(Color);
                case 'B': return new Bishop(Color);
                case 'N': return new Knight(Color);
                default: throw new ArgumentException($"Invalid piece type character '{piece}'");
            }
        }
    }
}

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
    }
}

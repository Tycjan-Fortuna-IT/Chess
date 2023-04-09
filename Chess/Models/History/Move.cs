namespace Chess.Models
{
    public class Move
    {
        public Tuple<int, int> FromField;

        public Tuple<int, int> ToField;

        public string MovedChess;

        public string? CapturedChessName;

        public Move(Tuple<int, int> FromField, Tuple<int, int> ToField, string MovedChess, string? CapturedChessName)
        {
            this.FromField = FromField;
            this.ToField = ToField;
            this.MovedChess = MovedChess;
            this.CapturedChessName = CapturedChessName;
        }
    }
}

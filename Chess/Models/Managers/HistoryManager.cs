namespace Chess.Models
{
    public class HistoryManager
    {
        public List<Move> Moves = new List<Move>();

        public void RegisterMove(Field First, Field Second, bool Passant, ColorEnum? CastleColor)
        {
            if (Passant)
            {
                Moves.Add(new Move(
                    new Tuple<int, int>(First.PosX, First.PosY),
                    new Tuple<int, int>(Second.PosX, Second.PosY),
                    First.Chess.ToString(),
                    First.Chess.Color,
                    "Pawn",
                    First.Chess.Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White
                ));
            }
            else if (CastleColor is not null)
            {
                Moves.Add(new Move(
                    new Tuple<int, int>(First.PosX, First.PosY),
                    new Tuple<int, int>(Second.PosX, Second.PosY),
                    "King",
                    CastleColor,
                    "King",
                    CastleColor,
                    false,
                    true
                ));
            }
            else
            {
                Moves.Add(new Move(
                    new Tuple<int, int>(First.PosX, First.PosY),
                    new Tuple<int, int>(Second.PosX, Second.PosY),
                    First.Chess.ToString(),
                    First.Chess.Color,
                    !Second.IsEmpty() ? Second.Chess.ToString() : null,
                    !Second.IsEmpty() ? Second.Chess.Color : null
                ));
            }
        }

        public void RegisterPromotion(Field PromotionField, IChess PromotionChoice)
        {
            Moves.Add(new Move(
                new Tuple<int, int>(PromotionField.PosX, PromotionField.PosY),
                new Tuple<int, int>(PromotionField.PosX, PromotionField.PosY),
                PromotionField.Chess.ToString(),
                PromotionField.Chess.Color,
                PromotionChoice.ToString(),
                PromotionChoice.Color,
                true
            ));
        }

        public void RegisterKingCheck(ColorEnum Color)
        {
            Moves.Add(new Move(
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(-1, -1),
                "King",
                Color,
                "King",
                Color,
                false,
                false,
                true
            ));
        }

    }
}

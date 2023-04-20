namespace Chess.Models
{
    public class HistoryManager
    {
        public List<Move> Moves = new List<Move>();

        /// <summary>
        ///     Register move into history, prepare for export.
        /// </summary>
        /// <param name="First">Move from field</param>
        /// <param name="Second">Move to field</param>
        /// <param name="Passant">If move was en passant capture</param>
        /// <param name="CastleColor">If move was castle, then color of king</param>
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

        /// <summary>
        ///     Register promotion into history, prepare for export.
        /// </summary>
        /// <param name="PromotionField">Where figure was promoted</param>
        /// <param name="PromotionChoice">To what figure was promoted</param>
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

        /// <summary>
        ///     Register check into history, prepare for export.
        /// </summary>
        /// <param name="Color">Checked king color</param>
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

using System.Collections.Generic;

namespace Chess.Models
{
    public class HistoryManager
    {
        public List<Move> Moves = new List<Move>();

        public void RegisterMove(Field First, Field Second, bool Passant)
        {
            if (!Passant)
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
            else
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

        [Obsolete]
        public void ApplyMoves(IBoard Board)
        {

        }
    }
}

namespace Chess.Models
{
    public class HistoryManager
    {
        public List<Move> Moves = new List<Move>();

        public void RegisterMove(Field First, Field Second)
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

        public void ApplyMoves(IBoard Board)
        {

        }
    }
}

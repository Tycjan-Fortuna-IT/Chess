namespace Chess.Models
{
    public class Chessboard : IBoard
    {
        public string Uuid { get; }

        public Chessboard()
        {
            this.Uuid = Guid.NewGuid().ToString();
        }
    }
}

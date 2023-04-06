namespace Chess.Models
{
    public class Chessboard : IBoard
    {
        private readonly int AMOUNT_OF_FIELDS = 64;

        public string Uuid { get; }

        public IField[] Fields { get; set; }

        public Chessboard()
        {
            this.Uuid = Guid.NewGuid().ToString();
            this.Fields = new IField[AMOUNT_OF_FIELDS];
        }
    }
}

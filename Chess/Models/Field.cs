namespace Chess.Models
{
    public class Field
    {
        public int PosX { get; }

        public int PosY { get; }

        public IChess? Chess { get; set; }

        public Chessboard Board;

        public Field(Chessboard Board, int PosX, int PosY)
        {
            this.Board = Board;
            this.PosX = PosX;
            this.PosY = PosY;
        }

        public void Display()
        {
            switch (Chess)
            {
                case null: System.Console.Write(' '); break;
                case Bishop: System.Console.Write('B'); break;
                case King: System.Console.Write('O'); break;
                case Knight: System.Console.Write('K'); break;
                case Pawn: System.Console.Write('P'); break;
                case Queen: System.Console.Write('Q'); break;
                case Rook: System.Console.Write('R'); break;
            }
        }

        public void AddChess(IChess Chess)
        {
            this.Chess = Chess;
            this.Chess.Field = this;
        }

        public void RemoveChess()
        {
            this.Chess = null;
        }

        public bool IsEmpty()
        {
            return this.Chess is null;
        }
    }
}

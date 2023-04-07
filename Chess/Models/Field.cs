namespace Chess.Models
{
    public class Field
    {
        public IChess? Chess { get; set; }

        public Field()
        {

        }

        public void AddChess(IChess Chess)
        {
            this.Chess = Chess;
        }

        public void RemoveChess(IChess Chess)
        {
            this.Chess = null;
        }
    }
}

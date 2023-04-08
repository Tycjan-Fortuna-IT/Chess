namespace Chess.Models
{
    public class Pawn : IChess
    {
        public Field Field { get; set; }

        public ColorEnum Color { get; }

        public Pawn(ColorEnum Color) 
        {
            this.Color = Color;
        }
    }
}

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

        /// <summary>
        ///     Returns a list of all Fields to which Pawn can go based on current position.
        /// </summary>
        /// <returns>List<IField></returns>
        public List<Field> GetAvailablePositions()
        {
            List<Field> AvailablePositions = new List<Field>();

            int x = Field.PosX;
            int y = Field.PosY + (this.Color == ColorEnum.White ? -1 : 1);

            if (Field.Board.IsPositionInBounds(x, y))
            {
                Field IteratedField = Field.Board.GetField(x, y);

                if (IteratedField.IsEmpty())
                {
                    AvailablePositions.Add(IteratedField);
                }
            }

            return AvailablePositions;
        }
    }
}

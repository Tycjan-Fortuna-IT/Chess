namespace Chess.Models
{
    public class Pawn : IChess
    {
        public Field Field { get; set; }

        public ColorEnum Color { get; }

        public System.Drawing.Bitmap Texture { get; }

        private bool HasMoved = false;

        public Pawn(ColorEnum Color)
        {
            this.Color = Color;

            this.Texture = Color == ColorEnum.White ?
                Properties.Resources.PawnWhite : Properties.Resources.PawnBlack;
        }

        /// <summary>
        ///     Returns a list of all Fields to which Pawn can go based on current position.
        /// </summary>
        /// <returns>List<IField></returns>
        public List<Field> GetAvailablePositions()
        {
            List<Field> AvailablePositions = new List<Field>();

            int direction = this.Color == ColorEnum.White ? -1 : 1;

            ColorEnum enemyColor = this.Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;

            int x = Field.PosX;
            int y = Field.PosY + direction;

            if (Field.Board.IsPositionInBounds(x, y))
            {
                Field IteratedField = Field.Board.GetField(x, y);

                if (IteratedField.IsEmpty())
                {
                    AvailablePositions.Add(IteratedField);
                }

                // Left side
                if (this.Field.CheckForProjectedObstacle(new Tuple<int, int>(-1, 1 * direction), enemyColor, 1))
                {
                    Field ProjectedField = Field.Board.GetField(this.Field.PosX - 1, this.Field.PosY + (1 * direction));

                    AvailablePositions.Add(ProjectedField);
                }

                // Right side
                if (this.Field.CheckForProjectedObstacle(new Tuple<int, int>(1, 1 * direction), enemyColor, 1))
                {
                    Field ProjectedField = Field.Board.GetField(this.Field.PosX + 1, this.Field.PosY + (1 * direction));

                    AvailablePositions.Add(ProjectedField);
                }
            }

            return AvailablePositions;
        }

        public override string ToString()
        {
            return "Pawn";
        }
    }
}

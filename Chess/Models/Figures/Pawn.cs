namespace Chess.Models
{
    public class Pawn : IChess
    {
        public Field Field { get; set; }

        public ColorEnum Color { get; }

        public bool HasMoved { get; set; }

        public bool EnPassantable = false;

        public Pawn(ColorEnum Color)
        {
            this.Color = Color;
        }

        /// <summary>
        ///     Move event called whenever chess is moved from one field to another.
        /// </summary>
        /// <param name="First">Moved from</param>
        /// <param name="Second">Moved to</param>
        public void MoveEvent(Field First, Field Second)
        {
            if (Math.Abs(Second.PosY - First.PosY) == 2)
                EnPassantable = true;

            this.HasMoved = true;
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

                // Two fields ahead
                if (!this.HasMoved && Field.Board.IsPositionInBounds(x, y + direction))
                {
                    Field AheadField = Field.Board.GetField(x, y + direction);

                    if (AheadField.IsEmpty())
                    {
                        AvailablePositions.Add(AheadField);
                    }
                }

                int PassantY = Field.PosY;

                // En Passant
                if (Field.Board.IsPositionInBounds(x - 1, PassantY))
                {
                    Field PassantField = Field.Board.GetField(x - 1, PassantY);

                    if (!PassantField.IsEmpty() && PassantField.Chess is Pawn && PassantField.Chess.Color == enemyColor && ((Pawn)PassantField.Chess).EnPassantable)
                    {
                        if (Field.Board.IsPositionInBounds(x - 1, PassantY + direction))
                        {
                            Field ToField = Field.Board.GetField(x - 1, PassantY + direction);

                            if (ToField.IsEmpty())
                                AvailablePositions.Add(ToField);
                        }                
                    }
                }

                if (Field.Board.IsPositionInBounds(x + 1, PassantY))
                {
                    Field PassantField = Field.Board.GetField(x + 1, PassantY);

                    if (!PassantField.IsEmpty() && PassantField.Chess is Pawn && PassantField.Chess.Color == enemyColor && ((Pawn)PassantField.Chess).EnPassantable)
                    {
                        if (Field.Board.IsPositionInBounds(x + 1, PassantY + direction))
                        {
                            Field ToField = Field.Board.GetField(x + 1, PassantY + direction);

                            if (ToField.IsEmpty())
                                AvailablePositions.Add(ToField);
                        }
                    }
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

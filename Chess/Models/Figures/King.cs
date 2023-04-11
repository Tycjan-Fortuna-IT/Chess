namespace Chess.Models
{
    public class King : IChess
    {
        public Field Field { get; set; }

        public ColorEnum Color { get; }

        public System.Drawing.Bitmap Texture { get; }

        public bool HasMoved { get; set; }

        /// <summary>
        ///     List contatining all allowed moves that King can do.
        /// </summary>
        private readonly List<Tuple<int, int>> AllowedMovePatterns = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(-1, -1),
            new Tuple<int, int>(-1, 0),
            new Tuple<int, int>(-1, 1),
            new Tuple<int, int>(0, -1),
            new Tuple<int, int>(0, 1),
            new Tuple<int, int>(1, -1),
            new Tuple<int, int>(1, 0),
            new Tuple<int, int>(1, 1),
        };

        public King(ColorEnum Color)
        {
            this.Color = Color;

            this.Texture = Color == ColorEnum.White ?
                Properties.Resources.KingWhite : Properties.Resources.KingBlack;

            this.HasMoved = false;
        }

        /// <summary>
        ///     Returns a list of all Fields to which King can go based on current position.
        /// </summary>
        /// <returns>List<IField></returns>
        public List<Field> GetAvailablePositions()
        {
            List<Field> AvailablePositions = new List<Field>();

            foreach (Tuple<int, int> Pattern in AllowedMovePatterns)
            {
                int x = Field.PosX + Pattern.Item1;
                int y = Field.PosY + Pattern.Item2;

                if (Field.Board.IsPositionInBounds(x, y))
                {
                    if (!this.Field.CheckForProjectedObstacle(Pattern, this.Color, 1))
                    {
                        Field IteratedField = Field.Board.GetField(x, y);

                        if (IteratedField.IsEmpty())
                        {
                            AvailablePositions.Add(IteratedField);
                        }
                        else if (IteratedField.Chess.Color != this.Color)
                        {
                            AvailablePositions.Add(IteratedField);
                        }
                    }
                }
            }

            return AvailablePositions;
        }

        public override string ToString()
        {
            return "King";
        }
    }
}

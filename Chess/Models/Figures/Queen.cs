namespace Chess.Models
{
    public class Queen : IChess
    {
        public Field Field { get; set; }

        public ColorEnum Color { get; }

        public System.Drawing.Bitmap Texture { get; }

        /// <summary>
        ///     List contatining all allowed moves that Queen can do.
        /// </summary>
        private readonly List<Tuple<int, int>> AllowedMovePatterns = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(-1, 0),
            new Tuple<int, int>(0, -1),
            new Tuple<int, int>(1, 0),
            new Tuple<int, int>(0, 1),
            new Tuple<int, int>(-1, -1),
            new Tuple<int, int>(-1, 1),
            new Tuple<int, int>(1, -1),
            new Tuple<int, int>(1, 1)
        };

        public Queen(ColorEnum Color)
        {
            this.Color = Color;

            this.Texture = Color == ColorEnum.White ?
                Properties.Resources.QueenWhite : Properties.Resources.QueenBlack;
        }

        /// <summary>
        ///     Returns a list of all Fields to which Queen can go based on current position.
        /// </summary>
        /// <returns>List<IField></returns>
        public List<Field> GetAvailablePositions()
        {
            List<Field> AvailablePositions = new List<Field>();

            foreach (Tuple<int, int> Pattern in AllowedMovePatterns)
            {
                int x = Field.PosX + Pattern.Item1;
                int y = Field.PosY + Pattern.Item2;

                while (Field.Board.IsPositionInBounds(x, y))
                {
                    Field IteratedField = Field.Board.GetField(x, y);

                    if (IteratedField.IsEmpty())
                    {
                        AvailablePositions.Add(IteratedField);
                    }

                    x += Pattern.Item1;
                    y += Pattern.Item2;
                }
            }

            return AvailablePositions;
        }
    }
}

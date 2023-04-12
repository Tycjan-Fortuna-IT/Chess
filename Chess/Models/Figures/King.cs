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
        ///     Move event called whenever chess is moved from one field to another.
        /// </summary>
        /// <param name="First">Moved from</param>
        /// <param name="Second">Moved to</param>
        public void MoveEvent(Field First, Field Second)
        {
            this.HasMoved = true;
        }

        /// <summary>
        ///     Returns a list of all Fields to which King can go based on current position.
        /// </summary>
        /// <returns>List<IField></returns>
        public List<Field> GetAvailablePositions()
        {
            List<Field> AvailablePositions = new List<Field>();

            ColorEnum EnemyColor = this.Color == ColorEnum.White ? ColorEnum.Black : ColorEnum.White;

            foreach (Tuple<int, int> Pattern in AllowedMovePatterns)
            {
                int x = Field.PosX + Pattern.Item1;
                int y = Field.PosY + Pattern.Item2;

                if (Field.Board.IsPositionInBounds(x, y))
                {
                    if (!this.Field.CheckForProjectedObstacle(Pattern, this.Color, 1))
                    {
                        Field IteratedField = Field.Board.GetField(x, y);

                        if (IteratedField.IsEmpty() && !this.Field.Board.IsFieldBeingAttacked(IteratedField, EnemyColor))
                        {
                            AvailablePositions.Add(IteratedField);
                        }
                        else if (!IteratedField.IsEmpty() && IteratedField.Chess.Color != this.Color)
                        {
                            AvailablePositions.Add(IteratedField);
                        }
                    }
                }
            }

            // Castle
            if (!this.HasMoved)
            {
                Dictionary<string, List<Tuple<int, int>>> Placement = 
                    this.Field.Board.FigureSets[this.Color == ColorEnum.White ? "White" : "Black"].GetCastleFields(this.Color);

                Tuple<int, int> QueensideRook = Placement["QueensideRook"].First();
                List<Tuple<int, int>> Queenside = Placement["QueensideFields"];
                List<Tuple<int, int>> Kingside = Placement["KingsideFields"];
                Tuple<int, int> KingsideRook = Placement["KingsideRook"].First();

                Field QueensideRookField = this.Field.Board.GetField(QueensideRook.Item1, QueensideRook.Item2);
                Field KingsideRookField = this.Field.Board.GetField(KingsideRook.Item1, KingsideRook.Item2);

                List<Field> QueensideFields = new List<Field>();
                List<Field> KingsideFields = new List<Field>();

                foreach (Tuple<int, int> Tuple in Queenside)
                {
                    QueensideFields.Add(this.Field.Board.GetField(Tuple.Item1, Tuple.Item2));
                }

                foreach (Tuple<int, int> Tuple in Kingside)
                {
                    KingsideFields.Add(this.Field.Board.GetField(Tuple.Item1, Tuple.Item2));
                }

                if (QueensideRookField.Chess is Rook && !QueensideRookField.Chess.HasMoved)
                {
                    bool AreQueensideFieldsEmpty = true;
                    bool AreQueensideFieldsBeingAttacked = false;

                    foreach (Field QueensideField in QueensideFields)
                    {
                        if (!QueensideField.IsEmpty())
                        {
                            AreQueensideFieldsEmpty = false;
                            break;
                        }

                        if (this.Field.Board.IsFieldBeingAttacked(QueensideField, EnemyColor))
                        {
                            AreQueensideFieldsBeingAttacked = true;
                            break;
                        }
                    }


                    if (AreQueensideFieldsEmpty && !AreQueensideFieldsBeingAttacked)
                    {
                        AvailablePositions.Add(QueensideRookField);
                    }
                }

                if (KingsideRookField.Chess is Rook && !KingsideRookField.Chess.HasMoved)
                {
                    bool AreKingsideFieldsEmpty = true;
                    bool AreKingsideFieldsBeingAttacked = false;

                    foreach (Field KingsideField in KingsideFields)
                    {
                        if (!KingsideField.IsEmpty())
                        {
                            AreKingsideFieldsEmpty = false;
                            break;
                        }

                        if (this.Field.Board.IsFieldBeingAttacked(KingsideField, EnemyColor))
                        {
                            AreKingsideFieldsBeingAttacked = true;
                            break;
                        }
                    }

                    if (AreKingsideFieldsEmpty && !AreKingsideFieldsBeingAttacked)
                    {
                        AvailablePositions.Add(KingsideRookField);
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

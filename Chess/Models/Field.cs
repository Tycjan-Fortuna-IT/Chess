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

        /// <summary>
        ///     Attach Chess to the Field.
        /// </summary>
        /// <param name="Chess">Chess that will be attached</param>
        public void AddChess(IChess Chess)
        {
            this.Chess = Chess;
            this.Chess.Field = this;
        }

        /// <summary>
        ///     Detach Chess from the Field.
        /// </summary>
        public void RemoveChess()
        {
            this.Chess = null;
        }

        /// <summary>
        ///     Check whether there is any Chess attached.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty()
        {
            return this.Chess is null;
        }

        /// <summary>
        ///     Check whether on a given direction there exist a obstacle of given color within
        ///     a certain range
        /// </summary>
        /// <param name="Direction">Two coordinate direction vector od projection movement</param>
        /// <param name="Color">Color of detected obstacles</param>
        /// <param name="Range">Range up to which obstacles should be detected, in terms of Fields</param>
        /// <returns>bool</returns>
        public bool CheckForProjectedObstacle(Tuple<int, int> Direction, ColorEnum Color, int Range)
        {
            return this.FindProjectedFigures(Direction, Color, Range).Count() > 0 ? true : false;
        }

        /// <summary>
        ///     Get all obstacles on a given direction of given color within a certain range
        /// </summary>
        /// <param name="Direction">Two coordinate direction vector od projection movement</param>
        /// <param name="Color">Color of detected obstacles</param>
        /// <param name="Range">Range up to which obstacles should be detected, in terms of Fields</param>
        /// <returns>List<IChess> of all obstacles</returns>
        public List<IChess> FindProjectedFigures(Tuple<int, int> Direction, ColorEnum Color, int Range)
        {
            List<IChess> ProjectedFigures = new List<IChess>();

            int DirectionX = this.PosX + Direction.Item1;
            int DirectionY = this.PosY + Direction.Item2;

            for (int i = 0; i < Range; i++)
            {
                if (!this.Board.IsPositionInBounds(DirectionX, DirectionY))
                    break;

                Field IteratedField = this.Board.GetField(DirectionX, DirectionY);

                if (!IteratedField.IsEmpty())
                {
                    if (IteratedField.Chess.Color != Color)
                        break;

                    ProjectedFigures.Add(IteratedField.Chess);
                }

                DirectionX += Direction.Item1;
                DirectionY += Direction.Item2;
            }

            return ProjectedFigures;
        }
    }
}

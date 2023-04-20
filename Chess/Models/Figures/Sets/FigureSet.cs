namespace Chess.Models
{
    public class FigureSet
    {
        public List<IChess> Figures = new List<IChess>();

        private ColorEnum Color;

        public IFigureSet FigureSetPlacement { get; }

        public FigureSet(IFigureSet FigureSetPlacement, ColorEnum Color)
        {
            this.FigureSetPlacement = FigureSetPlacement;

            this.Color = Color;
        }

        /// <summary>
        ///     Fill board with set.
        /// </summary>
        /// <param name="Chessboard">Chessboard to be filled</param>
        public void PlaceFiguresOnBoard(Chessboard Chessboard)
        {
            this.FigureSetPlacement.Generate(Chessboard, Figures, Color);
        }

        /// <summary>
        ///     Get castle fields for specified color.
        /// </summary>
        /// <param name="Color">Color of returned set of fields</param>
        /// <returns>Map of coordinates of all castle fields</returns>
        public Dictionary<string, List<Tuple<int, int>>> GetCastleFields(ColorEnum Color)
        {
            return this.FigureSetPlacement.GetCastleFields(Color);
        }
    }
}

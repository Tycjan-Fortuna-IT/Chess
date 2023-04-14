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

        public void PlaceFiguresOnBoard(Chessboard Chessboard)
        {
            this.FigureSetPlacement.Generate(Chessboard, Figures, Color);
        }

        public Dictionary<string, List<Tuple<int, int>>> GetCastleFields(ColorEnum Color)
        {
            return this.FigureSetPlacement.GetCastleFields(Color);
        }

        //public IChess GetFigureOnPosition(int x, int y)
        //{
        //    return null;
        //}
    }
}

namespace Chess.Models
{
    public class FigureSet
    {
        public List<IChess> Figures = new List<IChess>();

        private ColorEnum Color;

        private IFigureSet FigureSetPlacement;

        public FigureSet(IFigureSet FigureSetPlacement, ColorEnum Color)
        {
            this.FigureSetPlacement = FigureSetPlacement;

            this.Color = Color;
        }

        public void PlaceFiguresOnBoard(Chessboard Chessboard)
        {
            FigureSetPlacement.Generate(Chessboard, Figures, Color);
        }

        //public IChess GetFigureOnPosition(int x, int y)
        //{
        //    return null;
        //}
    }
}

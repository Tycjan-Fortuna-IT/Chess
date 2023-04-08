namespace Chess.Models
{
    public interface IFigureSet
    {
        void Generate(Chessboard Chessboard, List<IChess> Figures, ColorEnum Color);
    }
}

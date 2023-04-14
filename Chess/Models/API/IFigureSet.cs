namespace Chess.Models
{
    public interface IFigureSet
    {
        void Generate(Chessboard Chessboard, List<IChess> Figures, ColorEnum Color);

        List<Tuple<int, int>> GetPromotionMap(ColorEnum Color);

        Dictionary<string, List<Tuple<int, int>>> GetCastleFields(ColorEnum Color);
    }
}

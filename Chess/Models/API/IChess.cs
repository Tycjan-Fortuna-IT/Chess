namespace Chess.Models
{
    public interface IChess
    {
        Field Field { get; set; }

        ColorEnum Color { get; }

        List<Field> GetAvailablePositions();
    }
}

namespace Chess.Models
{
    public interface IChess
    {
        Field Field { get; set; }

        ColorEnum Color { get; }

        System.Drawing.Bitmap Texture { get; }

        List<Field> GetAvailablePositions();
    }
}

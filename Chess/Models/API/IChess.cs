namespace Chess.Models
{
    public interface IChess
    {
        Field Field { get; set; }

        ColorEnum Color { get; }

        public bool HasMoved { get; set; }

        List<Field> GetAvailablePositions();

        void MoveEvent(Field First, Field Second);
    }
}

namespace Chess.Models
{
    public interface IBoard
    {
        string Uuid { get; }

        IField[] Fields { get; set; }
    }
}

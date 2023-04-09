namespace Chess.Models
{
    public interface ISerializer
    {
        void Save(Chessboard Board, string path);
    }
}

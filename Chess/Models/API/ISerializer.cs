namespace Chess.Models
{
    public interface ISerializer
    {
        void Save(Chessboard Board, string path);

        void Load(Chessboard Board, string path);
    }
}

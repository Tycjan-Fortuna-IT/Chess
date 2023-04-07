using Chess.Models;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();

            //chessboard.Display();

            Bishop bishop = new Bishop();

            chessboard.GetField(0, 7).AddChess(bishop);

            System.Console.WriteLine(bishop.GetAvailablePositions().Count());

            foreach (var Field in bishop.GetAvailablePositions())
            {
                Field.RemoveChess();
                Field.AddChess(new King());
            }

            //chessboard.Fields[14].AddChess(new Bishop());

            //chessboard.Fields[24].AddChess(new Bishop());

            chessboard.Display();

        }
    }
}

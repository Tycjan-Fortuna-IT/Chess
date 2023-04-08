using Chess.Models;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();

            //chessboard.Display();

            King king = new King(ColorEnum.White);

            Bishop bishop = new Bishop(ColorEnum.White);

            chessboard.GetField(3, 3).AddChess(king);

            System.Console.WriteLine(king.GetAvailablePositions().Count());

            foreach (var Field in king.GetAvailablePositions())
            {
                Field.RemoveChess();
                Field.AddChess(new King(ColorEnum.White));
            }

            //chessboard.Fields[14].AddChess(new Bishop());

            //chessboard.Fields[24].AddChess(new Bishop());

            chessboard.Display();

        }
    }
}

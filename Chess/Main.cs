using Chess.Models;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();

            //chessboard.Display();

            Knight knight = new Knight();

            chessboard.GetField(3, 3).AddChess(knight);

            System.Console.WriteLine(knight.GetAvailablePositions().Count());

            foreach (var Field in knight.GetAvailablePositions())
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

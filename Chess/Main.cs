using Chess.Models;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard();

            //chessboard.Display();
            //FigureSet WhiteFigureSet = new FigureSet(new DefaultFigureSet(), ColorEnum.White);

            //WhiteFigureSet.PlaceFiguresOnBoard(chessboard);

            chessboard.SaveToXML();

            //Bishop bishop = new Bishop(ColorEnum.White);

            //chessboard.GetField(3, 3).AddChess(pawn);

            //System.Console.WriteLine(pawn.GetAvailablePositions().Count());

            //foreach (var Field in pawn.GetAvailablePositions())
            //{
            //    Field.RemoveChess();
            //    Field.AddChess(new King(ColorEnum.White));
            //}

            //chessboard.Fields[14].AddChess(new Bishop());

            //chessboard.Fields[24].AddChess(new Bishop());

            //chessboard.Display();

        }
    }
}

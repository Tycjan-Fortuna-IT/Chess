using Chess.Models;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard(new Dictionary<string, FigureSet>
            {
                { "Black", new FigureSet(new DefaultFigureSet(), ColorEnum.Black) },
                { "White", new FigureSet(new DefaultFigureSet(), ColorEnum.White) }
            });

            //chessboard.GetField(1, 1).AddChess(new Bishop(ColorEnum.White));

            //var t = chessboard.GetField(3, 3).CheckForProjectedObstacle(new Tuple<int, int>(-1, -1), ColorEnum.White, 2);

            //System.Console.WriteLine(t);
            //chessboard.Display();


            //BlackFigureSet.PlaceFiguresOnBoard(chessboard);
            //WhiteFigureSet.PlaceFiguresOnBoard(chessboard);

            //chessboard.Load("C:\\Users\\tycja\\Desktop\\t.xml");

            //chessboard.Display();



            //chessboard.MoveFromFieldToField(chessboard.GetField(0, 1), chessboard.GetField(0, 2));
            //chessboard.Display();
            //chessboard.MoveFromFieldToField(chessboard.GetField(0, 2), chessboard.GetField(0, 3));
            //chessboard.Display();
            //chessboard.MoveFromFieldToField(chessboard.GetField(0, 3), chessboard.GetField(0, 4));
            //chessboard.Display();
            //chessboard.MoveFromFieldToField(chessboard.GetField(0, 4), chessboard.GetField(0, 5));
            //chessboard.Display();
            //chessboard.MoveFromFieldToField(chessboard.GetField(0, 5), chessboard.GetField(0, 6));
            //chessboard.Display();

            //chessboard.SaveToXML();

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

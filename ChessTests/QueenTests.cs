using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class QueenTests
    {
        private Chessboard Chessboard = new Chessboard(new Dictionary<string, FigureSet>());

        [TestMethod]
        public void QueenMovementTest()
        {
            Queen Queen = new Queen(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            Chessboard.GetField(0, 0).AddChess(Queen);

            List<Field> AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));

            Chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            Chessboard.GetField(7, 0).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));

            Chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            Chessboard.GetField(0, 7).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 6)));

            Chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            Chessboard.GetField(7, 7).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 6)));

            Chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            Chessboard.GetField(3, 0).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));

            Chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            Chessboard.GetField(0, 3).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 7)));

            Chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            Chessboard.GetField(3, 7).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));

            Chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            Chessboard.GetField(7, 3).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));

            Chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            Chessboard.GetField(3, 3).AddChess(Queen);

            AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));

            Chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void QueenCaptureTest()
        {
            Queen Queen = new Queen(ColorEnum.Black);

            Pawn Pawn = new Pawn(ColorEnum.White);

            King King = new King(ColorEnum.Black);

            Field First = this.Chessboard.GetField(0, 0);
            Field Second = this.Chessboard.GetField(0, 1);
            Field Third = this.Chessboard.GetField(2, 0);

            First.AddChess(Queen);
            Second.AddChess(Pawn);
            Third.AddChess(King);

            List<Field> AvailablePositions = Queen.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
        }

        [TestMethod]
        public void QueenOtherMethodsTest()
        {
            Queen Queen = new Queen(ColorEnum.Black);

            Assert.AreEqual("Queen", Queen.ToString());

            Field First = new Field(Chessboard, 0, 0);
            Field Second = new Field(Chessboard, 1, 1);

            Assert.AreEqual(false, Queen.HasMoved);

            Queen.MoveEvent(First, Second);

            Assert.AreEqual(true, Queen.HasMoved);
        }
    }
}

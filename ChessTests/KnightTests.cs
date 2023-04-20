using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class KnightTests
    {
        private Chessboard Chessboard = new Chessboard(new Dictionary<string, FigureSet>());

        [TestMethod]
        public void KnightMovementTest()
        {
            Knight Knight = new Knight(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            Chessboard.GetField(0, 0).AddChess(Knight);

            List<Field> AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));

            Chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            Chessboard.GetField(7, 0).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 2)));

            Chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            Chessboard.GetField(0, 7).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 6)));

            Chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            Chessboard.GetField(7, 7).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 6)));

            Chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            Chessboard.GetField(3, 0).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 1)));

            Chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            Chessboard.GetField(0, 3).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 5)));

            Chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            Chessboard.GetField(3, 7).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 6)));

            Chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            Chessboard.GetField(7, 3).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 5)));

            Chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            Chessboard.GetField(3, 3).AddChess(Knight);

            AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 4)));

            Chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void KnightCaptureTest()
        {
            Knight Knight = new Knight(ColorEnum.Black);

            Rook Rook = new Rook(ColorEnum.White);

            Field First = this.Chessboard.GetField(0, 0);
            Field Second = this.Chessboard.GetField(2, 1);

            First.AddChess(Knight);
            Second.AddChess(Rook);

            List<Field> AvailablePositions = Knight.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
        }

        [TestMethod]
        public void KnightOtherMethodsTest()
        {
            Knight Knight = new Knight(ColorEnum.Black);

            Assert.AreEqual("Knight", Knight.ToString());

            Field First = new Field(Chessboard, 0, 0);
            Field Second = new Field(Chessboard, 1, 1);

            Assert.AreEqual(false, Knight.HasMoved);

            Knight.MoveEvent(First, Second);

            Assert.AreEqual(true, Knight.HasMoved);
        }
    }
}
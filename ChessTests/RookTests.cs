using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class RookTests
    {
        private Chessboard Chessboard = new Chessboard(new Dictionary<string, FigureSet>());

        [TestMethod]
        public void RookMovementTest()
        {
            Rook Rook = new Rook(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            Chessboard.GetField(0, 0).AddChess(Rook);

            List<Field> AvailablePositions = Rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));

            Chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            Chessboard.GetField(7, 0).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));

            Chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            Chessboard.GetField(0, 7).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

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

            Chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            Chessboard.GetField(7, 7).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

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

            Chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            Chessboard.GetField(3, 0).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

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

            Chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            Chessboard.GetField(0, 3).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

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

            Chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            Chessboard.GetField(3, 7).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

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

            Chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            Chessboard.GetField(7, 3).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));

            Chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            Chessboard.GetField(3, 3).AddChess(Rook);

            AvailablePositions = Rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));

            Chessboard.GetField(3, 3).RemoveChess();
        }


        [TestMethod]
        public void RookCaptureTest()
        {
            Rook Rook = new Rook(ColorEnum.Black);

            Pawn Pawn = new Pawn(ColorEnum.White);

            King King = new King(ColorEnum.Black);

            Field First = this.Chessboard.GetField(0, 0);
            Field Second = this.Chessboard.GetField(0, 1);
            Field Third = this.Chessboard.GetField(2, 0);

            First.AddChess(Rook);
            Second.AddChess(Pawn);
            Third.AddChess(King);

            List<Field> AvailablePositions = Rook.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
        }

        [TestMethod]
        public void RookOtherMethodsTest()
        {
            Rook Rook = new Rook(ColorEnum.Black);

            Assert.AreEqual("Rook", Rook.ToString());

            Field First = new Field(Chessboard, 0, 0);
            Field Second = new Field(Chessboard, 1, 1);

            Assert.AreEqual(false, Rook.HasMoved);

            Rook.MoveEvent(First, Second);

            Assert.AreEqual(true, Rook.HasMoved);
        }
    }
}

using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class BishopTests
    {
        Chessboard Chessboard = new Chessboard(new Dictionary<string, FigureSet>());
        
        [TestMethod]
        public void BishopMovementTest()
        {

            Bishop Bishop = new Bishop(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            Chessboard.GetField(0, 0).AddChess(Bishop);

            List<Field> AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 7)));

            Chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            Chessboard.GetField(7, 0).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 7)));

            Chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            Chessboard.GetField(0, 7).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 0)));

            Chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            Chessboard.GetField(7, 7).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 6)));

            Chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            Chessboard.GetField(3, 0).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));

            Chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            Chessboard.GetField(0, 3).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 7)));

            Chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            Chessboard.GetField(3, 7).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 3)));

            Chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            Chessboard.GetField(7, 3).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(5, 5)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 7)));

            Chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            Chessboard.GetField(3, 3).AddChess(Bishop);

            AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 0)));
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
        public void BishopCaptureTest()
        {
            Bishop Bishop = new Bishop(ColorEnum.Black);

            Pawn Pawn = new Pawn(ColorEnum.White);

            King King = new King(ColorEnum.Black);

            Field First = this.Chessboard.GetField(3, 3);
            Field Second = this.Chessboard.GetField(1, 1);
            Field Third = this.Chessboard.GetField(5, 5);

            First.AddChess(Bishop);
            Second.AddChess(Pawn);
            Third.AddChess(King);

            List<Field> AvailablePositions = Bishop.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
        }

        [TestMethod]
        public void BishopOtherMethodsTest()
        {
            Bishop Bishop = new Bishop(ColorEnum.Black);

            Assert.AreEqual("Bishop", Bishop.ToString());

            Field First = new Field(Chessboard, 0, 0);
            Field Second = new Field(Chessboard, 1, 1);

            Assert.AreEqual(false, Bishop.HasMoved);

            Bishop.MoveEvent(First, Second);

            Assert.AreEqual(true, Bishop.HasMoved);
        }
    }
}

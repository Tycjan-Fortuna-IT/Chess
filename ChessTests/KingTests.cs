using Chess.Models;

namespace ChessTests
{
    [TestClass]
    public class KingTests
    {
        Chessboard Chessboard = new Chessboard(new Dictionary<string, FigureSet>());

        [TestMethod]
        public void KingMovementTest()
        {
            King king = new King(ColorEnum.White);

            // ------ LEFT UP CORNER ------
            Chessboard.GetField(0, 0).AddChess(king);

            List<Field> AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));

            Chessboard.GetField(0, 0).RemoveChess();

            // ------ RIGHT UP CORNER ------
            Chessboard.GetField(7, 0).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 1)));

            Chessboard.GetField(7, 0).RemoveChess();

            // ------ LEFT DOWN CORNER ------
            Chessboard.GetField(0, 7).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 7)));

            Chessboard.GetField(0, 7).RemoveChess();

            // ------ RIGHT DOWN CORNER ------
            Chessboard.GetField(7, 7).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 7)));

            Chessboard.GetField(7, 7).RemoveChess();

            // ------ TOP BORDER CENTER ------
            Chessboard.GetField(3, 0).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 0)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 1)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 1)));

            Chessboard.GetField(3, 0).RemoveChess();

            // ------ LEFT BORDER CENTER ------
            Chessboard.GetField(0, 3).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(1, 4)));

            Chessboard.GetField(0, 3).RemoveChess();

            // ------ DOWN BORDER CENTER ------
            Chessboard.GetField(3, 7).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 7)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 6)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 6)));

            Chessboard.GetField(3, 7).RemoveChess();

            // ------ RIGHT BORDER CENTER ------
            Chessboard.GetField(7, 3).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(7, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(6, 4)));

            Chessboard.GetField(7, 3).RemoveChess();

            // ------ CENTER ------
            Chessboard.GetField(3, 3).AddChess(king);

            AvailablePositions = king.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 2)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 3)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(2, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(3, 4)));
            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(4, 4)));

            Chessboard.GetField(3, 3).RemoveChess();
        }

        [TestMethod]
        public void KingCaptureTest()
        {
            King King = new King(ColorEnum.Black);

            Pawn Pawn = new Pawn(ColorEnum.White);

            Field First = this.Chessboard.GetField(0, 0);
            Field Second = this.Chessboard.GetField(0, 1);

            First.AddChess(King);
            Second.AddChess(Pawn);

            List<Field> AvailablePositions = King.GetAvailablePositions();

            Assert.IsTrue(AvailablePositions.Contains(Chessboard.GetField(0, 1)));
        }

        [TestMethod]
        public void KingCastleTest()
        {
            Chessboard Board = new Chessboard(new Dictionary<string, FigureSet>()
            {
                { "Black", new FigureSet(new DefaultFigureSet(), ColorEnum.Black) },
            });

            King king = (King)Board.GetField(4, 0).Chess;

            king.GetAvailablePositions();

            Board.GetField(1, 0).RemoveChess();
            Board.GetField(2, 0).RemoveChess();
            Board.GetField(3, 0).RemoveChess();

            Board.GetField(5, 0).RemoveChess();
            Board.GetField(6, 0).RemoveChess();

            king.GetAvailablePositions();

            Knight KnightLeft = new Knight(ColorEnum.White);
            Knight KnightRight = new Knight(ColorEnum.White);

            Board.GetField(1, 2).AddChess(KnightLeft);
            Board.GetField(6, 2).AddChess(KnightRight);

            king.GetAvailablePositions();
        }

        [TestMethod]
        public void KingCheckTest()
        {

        }

        [TestMethod]
        public void KingCheckMateTest()
        {

        }

        [TestMethod]
        public void KingOtherMethodsTest()
        {
            King King = new King(ColorEnum.Black);

            Assert.AreEqual("King", King.ToString());

            Field First = new Field(Chessboard, 0, 0);
            Field Second = new Field(Chessboard, 1, 2);

            Assert.AreEqual(false, King.HasMoved);

            King.MoveEvent(First, Second);

            Assert.AreEqual(true, King.HasMoved);
        }
    }
}
